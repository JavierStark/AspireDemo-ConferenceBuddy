/// <reference types="vite/client" />

interface ImportMetaEnv {
  readonly VITE_SESSIONS_API: string
  readonly VITE_INSIGHTS_API: string
}

interface ImportMeta {
  readonly env: ImportMetaEnv
}
