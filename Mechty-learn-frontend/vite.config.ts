import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

console.log("is dev:" + process.env.VITE_DEV_SERVER)
export default defineConfig({
  plugins: [react()],
  build: {
    outDir: 'dist',
  },
  server: {
    proxy: {
      '/api': {
        target: process.env.VITE_DEV_SERVER === 'true' ? 'http://localhost:8080' : 'https://mechty-learn.onrender.com',
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, ''),
      },
    }
  },
})
