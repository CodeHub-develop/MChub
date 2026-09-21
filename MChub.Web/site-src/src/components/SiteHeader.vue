<script setup>
import { icons } from '../data/icons.js'
import { site } from '../data/site.js'
import iconUrl from '../assets/icon.png'

const nav = [
  { href: '#features', label: '功能' },
  { href: '#download', label: '下载' },
  { href: '#open-source', label: '开源' },
]
</script>

<template>
  <header class="hdr">
    <div class="hdr-inner">
      <a href="#top" class="brand">
        <img class="brand-logo" :src="iconUrl" alt="MChub" />
        <span class="brand-name">MChub</span>
      </a>

      <nav class="nav">
        <a v-for="n in nav" :key="n.href" :href="n.href" class="nav-link">{{ n.label }}</a>
      </nav>

      <a class="btn btn-ghost gh-btn" :href="site.github" target="_blank" rel="noopener noreferrer">
        <span class="icon" v-html="icons.github"></span>
        <span>GitHub</span>
      </a>
    </div>
  </header>
</template>

<style scoped>
.hdr {
  position: sticky;
  top: 0;
  z-index: 50;
  backdrop-filter: blur(14px);
  background: rgba(9, 12, 8, 0.72);
  border-bottom: 1px solid var(--line);
}
.hdr-inner {
  max-width: var(--maxw);
  margin: 0 auto;
  padding: 12px 24px;
  display: flex;
  align-items: center;
  gap: 28px;
}
.brand {
  display: flex;
  align-items: center;
  gap: 10px;
  font-weight: 800;
  font-size: 19px;
  letter-spacing: 0.02em;
}
.brand-logo {
  width: 30px;
  height: 30px;
  border-radius: 8px;
}
.nav {
  display: flex;
  gap: 4px;
  margin-left: 8px;
}
.nav-link {
  padding: 7px 14px;
  border-radius: 10px;
  color: var(--text-dim);
  font-size: 15px;
  transition: color 0.2s, background-color 0.2s;
}
.nav-link:hover {
  color: var(--text);
  background: var(--panel);
}
.gh-btn {
  margin-left: auto;
  padding: 9px 16px;
  font-size: 14px;
  gap: 8px;
}
.gh-btn .icon {
  font-size: 16px;
}

@media (max-width: 640px) {
  .nav {
    display: none;
  }
}
</style>
