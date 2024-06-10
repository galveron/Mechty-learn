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
        target: 'https://mechty-learn.onrender.com',
        changeOrigin: true,
      },
    }
  },
  preview: {
    proxy: {
      '/api': {
        target: 'https://mechty-learn.onrender.com',
        changeOrigin: true,
      },
    },
    port: 5000
  },
})
