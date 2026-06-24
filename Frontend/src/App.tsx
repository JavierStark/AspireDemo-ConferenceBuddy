import { useEffect, useState } from 'react'

interface Session {
  id: number
  title: string
  description: string
  speakerName: string
  speakerBio: string
  room: string
  time: string
  tags: string[]
  maxAttendees: number
  isBookmarked: boolean
}

interface TrendingSession {
  sessionId: number
  reason: string
}

function App() {
  const [sessions, setSessions] = useState<Session[]>([])
  const [trending, setTrending] = useState<TrendingSession[]>([])
  const [related, setRelated] = useState<TrendingSession[]>([])
  const [selectedSession, setSelectedSession] = useState<number | null>(null)
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    const sessionsApi = import.meta.env.VITE_SESSIONS_API || ''
    const insightsApi = import.meta.env.VITE_INSIGHTS_API || ''

    Promise.all([
      fetch(`${sessionsApi}/api/sessions`).then(r => r.json()),
      fetch(`${insightsApi}/api/insights/trending`).then(r => r.json()),
    ])
      .then(([sessionsData, trendingData]) => {
        setSessions(sessionsData)
        setTrending(trendingData)
        setLoading(false)
      })
      .catch(err => {
        console.error('Failed to load data', err)
        setLoading(false)
      })
  }, [])

  const handleSessionClick = (id: number) => {
    const insightsApi = import.meta.env.VITE_INSIGHTS_API || ''
    setSelectedSession(id)
    fetch(`${insightsApi}/api/insights/related?sessionId=${id}`)
      .then(r => r.json())
      .then(setRelated)
      .catch(() => setRelated([]))
  }

  const handleBookmark = async (id: number) => {
    const sessionsApi = import.meta.env.VITE_SESSIONS_API || ''
    try {
      const res = await fetch(`${sessionsApi}/api/sessions/${id}/bookmark`, { method: 'POST' })
      const updated = await res.json()
      setSessions(prev => prev.map(s => s.id === id ? updated : s))
    } catch (err) {
      console.error('Bookmark failed', err)
    }
  }

  if (loading) {
    return <div className="loading">Loading schedule...</div>
  }

  const trendingSessions = sessions.filter(s => trending.some(t => t.sessionId === s.id))
  const relatedSessions = sessions.filter(s => related.some(r => r.sessionId === s.id))
  const mapReason = (sessionId: number) => {
    const item = trending.find(t => t.sessionId === sessionId)
    return item?.reason || related.find(r => r.sessionId === sessionId)?.reason || ''
  }

  return (
    <div className="app">
      <header>
        <h1>ConferenceBuddy</h1>
        <p className="subtitle">Your personal conference navigator</p>
      </header>

      <div className="dashboard">
        <div className="main-content">
          <section>
            <h2>Schedule</h2>
            <div className="session-grid">
              {sessions.map(session => (
                <div
                  key={session.id}
                  className={`session-card ${selectedSession === session.id ? 'selected' : ''}`}
                  onClick={() => handleSessionClick(session.id)}
                >
                  <div className="session-header">
                    <span className="time">{session.time}</span>
                    <span className="room">{session.room}</span>
                  </div>
                  <h3>{session.title}</h3>
                  <p className="speaker">{session.speakerName}</p>
                  <p className="desc">{session.description}</p>
                  <div className="tags">
                    {session.tags.map(tag => (
                      <span key={tag} className="tag">{tag}</span>
                    ))}
                  </div>
                  <button
                    className={`bookmark-btn ${session.isBookmarked ? 'active' : ''}`}
                    onClick={e => { e.stopPropagation(); handleBookmark(session.id) }}
                  >
                    {session.isBookmarked ? '★ Bookmarked' : '☆ Bookmark'}
                  </button>
                </div>
              ))}
            </div>
          </section>
        </div>

        <aside className="sidebar">
          <section>
            <h2>Trending Now</h2>
            <div className="insight-list">
              {trendingSessions.map(s => (
                <div key={s.id} className="insight-item" onClick={() => handleSessionClick(s.id)}>
                  <strong>{s.title}</strong>
                  <p>{mapReason(s.id)}</p>
                </div>
              ))}
            </div>
          </section>

          {selectedSession && (
            <section>
              <h2>Related Sessions</h2>
              <div className="insight-list">
                {relatedSessions.length === 0 && <p className="empty">No related sessions found.</p>}
                {relatedSessions.map(s => (
                  <div key={s.id} className="insight-item" onClick={() => handleSessionClick(s.id)}>
                    <strong>{s.title}</strong>
                    <p>{mapReason(s.id)}</p>
                  </div>
                ))}
              </div>
            </section>
          )}
        </aside>
      </div>
    </div>
  )
}

export default App
