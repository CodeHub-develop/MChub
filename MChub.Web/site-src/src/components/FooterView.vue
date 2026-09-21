<script setup>
import { icons } from '../data/icons.js'
import { site } from '../data/site.js'
import iconUrl from '../assets/icon.png'

const year = new Date().getFullYear()
</script>

<template>
  <footer class="ftr">
    <div class="ftr-inner">
      <div class="ftr-brand">
        <img class="ftr-logo" :src="iconUrl" alt="MChub" />
        <span>MChub</span>
      </div>
      <p class="ftr-note">{{ site.footer.note }}</p>
      <div class="ftr-links">
        <a :href="site.github" target="_blank" rel="noopener noreferrer">
          <span class="icon" v-html="icons.github"></span>
          GitHub
        </a>
        <a :href="site.qq.url" target="_blank" rel="noopener noreferrer">
          <span class="icon" v-html="icons.users"></span>
          QQ 群
        </a>
      </div>
      <p class="ftr-copy">© {{ year }} MChub · CodeHub</p>
    </div>
  </footer>
</template>

<style scoped>
.ftr {
  border-top: 1px solid var(--line);
  margin-top: 40px;
  padding: 40px 24px 48px;
}
.ftr-inner {
  max-width: var(--maxw);
  margin: 0 auto;
  text-align: center;
}
.ftr-brand {
  display: inline-flex;
  align-items: center;
  gap: 10px;
  font-weight: 800;
  font-size: 18px;
}
.ftr-logo {
  width: 26px;
  height: 26px;
  border-radius: 7px;
}
.ftr-note {
  color: var(--text-dim);
  font-size: 13px;
  margin-top: 14px;
}
.ftr-links {
  display: flex;
  gap: 22px;
  justify-content: center;
  margin-top: 18px;
}
.ftr-links a {
  display: inline-flex;
  align-items: center;
  gap: 7px;
  color: var(--text-dim);
  font-size: 14px;
  transition: color 0.2s;
}
.ftr-links a:hover {
  color: var(--accent-soft);
}
.ftr-copy {
  color: var(--text-faint);
  font-size: 12px;
  margin-top: 20px;
}
</style>
