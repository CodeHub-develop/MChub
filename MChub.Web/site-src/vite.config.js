import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// GitHub Pages 部署在子路径 /MChub/ 下，base 必须指到它，否则资源 404
export default defineConfig({
  base: '/MChub/',
  plugins: [vue()],
  build: {
    outDir: 'dist',
    assetsDir: 'assets',
    chunkSizeWarningLimit: 800,
  },
})
