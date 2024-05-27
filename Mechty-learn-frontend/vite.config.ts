import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
const backendUrl = process.env.BACKEND_URL ?? '';
// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  build: {
    outDir: 'dist',
  },
  server: {
    proxy: {
      '/api': backendUrl
    }
  }
})
