import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import * as dotenv from 'dotenv';

dotenv.config();

const backendUrl = process.env.VITE_BACKEND_URL ?? '';


export default defineConfig({
  plugins: [react()],
  build: {
    outDir: 'dist',
  },
  server: {
    proxy: {
      '/api': {
        target: "https://mechty-learn.onrender.com",
        changeOrigin: true,
        secure: false,
      },
    }
  },
  define: {
    'process.env': {
      VITE_BACKEND_URL: process.env.VITE_BACKEND_URL,
    },
  },
})
