import { jsx as _jsx, jsxs as _jsxs } from "react/jsx-runtime";
import { useEffect, useState } from 'react';
function App() {
    const [sessions, setSessions] = useState([]);
    const [trending, setTrending] = useState([]);
    const [related, setRelated] = useState([]);
    const [selectedSession, setSelectedSession] = useState(null);
    const [loading, setLoading] = useState(true);
    useEffect(() => {
        const sessionsApi = import.meta.env.VITE_SESSIONS_API || '';
        const insightsApi = import.meta.env.VITE_INSIGHTS_API || '';
        Promise.all([
            fetch(`${sessionsApi}/api/sessions`).then(r => r.json()),
            fetch(`${insightsApi}/api/insights/trending`).then(r => r.json()),
        ])
            .then(([sessionsData, trendingData]) => {
            setSessions(sessionsData);
            setTrending(trendingData);
            setLoading(false);
        })
            .catch(err => {
            console.error('Failed to load data', err);
            setLoading(false);
        });
    }, []);
    const handleSessionClick = (id) => {
        const insightsApi = import.meta.env.VITE_INSIGHTS_API || '';
        setSelectedSession(id);
        fetch(`${insightsApi}/api/insights/related?sessionId=${id}`)
            .then(r => r.json())
            .then(setRelated)
            .catch(() => setRelated([]));
    };
    const handleBookmark = async (id) => {
        const sessionsApi = import.meta.env.VITE_SESSIONS_API || '';
        try {
            const res = await fetch(`${sessionsApi}/api/sessions/${id}/bookmark`, { method: 'POST' });
            const updated = await res.json();
            setSessions(prev => prev.map(s => s.id === id ? updated : s));
        }
        catch (err) {
            console.error('Bookmark failed', err);
        }
    };
    if (loading) {
        return _jsx("div", { className: "loading", children: "Loading schedule..." });
    }
    const trendingSessions = sessions.filter(s => trending.some(t => t.sessionId === s.id));
    const relatedSessions = sessions.filter(s => related.some(r => r.sessionId === s.id));
    const mapReason = (sessionId) => {
        const item = trending.find(t => t.sessionId === sessionId);
        return item?.reason || related.find(r => r.sessionId === sessionId)?.reason || '';
    };
    return (_jsxs("div", { className: "app", children: [_jsxs("header", { children: [_jsx("h1", { children: "ConferenceBuddy" }), _jsx("p", { className: "subtitle", children: "Your personal conference navigator" })] }), _jsxs("div", { className: "dashboard", children: [_jsx("div", { className: "main-content", children: _jsxs("section", { children: [_jsx("h2", { children: "Schedule" }), _jsx("div", { className: "session-grid", children: sessions.map(session => (_jsxs("div", { className: `session-card ${selectedSession === session.id ? 'selected' : ''}`, onClick: () => handleSessionClick(session.id), children: [_jsxs("div", { className: "session-header", children: [_jsx("span", { className: "time", children: session.time }), _jsx("span", { className: "room", children: session.room })] }), _jsx("h3", { children: session.title }), _jsx("p", { className: "speaker", children: session.speakerName }), _jsx("p", { className: "desc", children: session.description }), _jsx("div", { className: "tags", children: session.tags.map(tag => (_jsx("span", { className: "tag", children: tag }, tag))) }), _jsx("button", { className: `bookmark-btn ${session.isBookmarked ? 'active' : ''}`, onClick: e => { e.stopPropagation(); handleBookmark(session.id); }, children: session.isBookmarked ? '★ Bookmarked' : '☆ Bookmark' })] }, session.id))) })] }) }), _jsxs("aside", { className: "sidebar", children: [_jsxs("section", { children: [_jsx("h2", { children: "Trending Now" }), _jsx("div", { className: "insight-list", children: trendingSessions.map(s => (_jsxs("div", { className: "insight-item", onClick: () => handleSessionClick(s.id), children: [_jsx("strong", { children: s.title }), _jsx("p", { children: mapReason(s.id) })] }, s.id))) })] }), selectedSession && (_jsxs("section", { children: [_jsx("h2", { children: "Related Sessions" }), _jsxs("div", { className: "insight-list", children: [relatedSessions.length === 0 && _jsx("p", { className: "empty", children: "No related sessions found." }), relatedSessions.map(s => (_jsxs("div", { className: "insight-item", onClick: () => handleSessionClick(s.id), children: [_jsx("strong", { children: s.title }), _jsx("p", { children: mapReason(s.id) })] }, s.id)))] })] }))] })] })] }));
}
export default App;
