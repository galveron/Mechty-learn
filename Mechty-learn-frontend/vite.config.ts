import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  build: {
    outDir: 'dist',
  },
  server: {
    proxy: {
      '/api': {
        target: process.env.DOTNET_BACKEND_URL || 'http://localhost:5019',
        changeOrigin: true,
      },
    }
  },
  preview: {
    proxy: {
      '/api': {
        target: process.env.DOTNET_BACKEND_URL || 'http://localhost:5019',
        changeOrigin: true,
      },
    }
  },
})
