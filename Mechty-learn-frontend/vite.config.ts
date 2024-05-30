import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

const backendUrl = process.env.DOTNET_BACKEND_URL || 'http://localhost:5019'

export default defineConfig({
  plugins: [react()],
  build: {
    outDir: 'dist',
  },
  server: {
    proxy: {
      '/api': {
        target: backendUrl,
        changeOrigin: true,
      },
    }
  },
  preview: {
    proxy: {
      '/api': {
        target: backendUrl,
        changeOrigin: true,
      },
    }
  },
})
