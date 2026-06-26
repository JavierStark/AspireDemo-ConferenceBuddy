import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  server: {
    host: true,
    allowedHosts: true,
    proxy: {
      '/api/sessions': {
        target: process.env.SESSIONS_API_HTTP || 'http://localhost:5000',
        changeOrigin: true,
      },
      '/api/insights': {
        target: process.env.INSIGHTS_API_HTTP || 'http://localhost:8000',
        changeOrigin: true,
      },
    },
  },
})
