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
        target: process.env.VITE_DEV_SERVER === 'true' || process.env.VITE_DEV_SERVER === 'undefined' ? 'https://mechty-learn.onrender.com' : 'https://mechty-learn.onrender.com',
        changeOrigin: true,
      },
    }
  },
})
