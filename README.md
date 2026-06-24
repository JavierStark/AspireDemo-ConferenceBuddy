# ConferenceBuddy

A .NET Aspire distributed application for browsing the OpenSouthCode 2026 conference schedule, built with:

- **Sessions API** — ASP.NET Core 10 (C#) serving session data from PostgreSQL
- **Insights API** — FastAPI (Python) providing trending/related recommendations via Redis
- **Frontend** — React 19 + TypeScript + Vite
- **Orchestrator** — .NET Aspire AppHost wiring all services together

## Architecture

```
AppHost (orchestrator)
├── SessionsApi (C# / .NET 10) → PostgreSQL
├── insights-api (Python / FastAPI) → Redis
└── Frontend (React / Vite / TypeScript)
```

## Getting Started

```bash
# Install Aspire workload
dotnet workload install aspire

# Run the app
aspire start
```

The dashboard will open at the URL shown in the terminal.

## Sessions

All 57 sessions from OpenSouthCode 2026 (June 26–27) are seeded into the database, covering topics like cryptography, Kubernetes, RISC-V, AI agents, Flutter, Java 26/27, observability, and more.
