import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import './src/vite-env';

const backendUrl = import.meta.env.VITE_BACKEND_URL ?? '';
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
