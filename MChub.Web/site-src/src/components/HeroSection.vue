<script setup>
import { icons } from '../data/icons.js'
import { site } from '../data/site.js'
import iconUrl from '../assets/icon.png'

function scrollToDownload() {
  document.getElementById('download')?.scrollIntoView({ behavior: 'smooth' })
}
</script>

<template>
  <section id="top" class="hero">
    <div class="hero-inner">
      <div class="hero-glow" aria-hidden="true"></div>

      <img class="hero-icon" :src="iconUrl" alt="MChub 图标" />

      <h1 class="hero-title">{{ site.heroTitle }}</h1>
      <p class="hero-slogan">{{ site.slogan }}</p>
      <p class="hero-intro">{{ site.intro }}</p>

      <div class="hero-actions">
        <button class="btn btn-primary" @click="scrollToDownload">
          <span class="icon" v-html="icons.download"></span>
          <span>下载 MChub</span>
        </button>
        <a class="btn btn-ghost" :href="site.github" target="_blank" rel="noopener noreferrer">
          <span class="icon" v-html="icons.github"></span>
          <span>查看源码</span>
        </a>
      </div>
    </div>
  </section>
</template>

<style scoped>
.hero {
  position: relative;
  overflow: hidden;
  padding: 96px 24px 88px;
}
.hero-inner {
  position: relative;
  max-width: 720px;
  margin: 0 auto;
  text-align: center;
}
.hero-glow {
  position: absolute;
  top: -140px;
  left: 50%;
  transform: translateX(-50%);
  width: 640px;
  height: 400px;
  background: radial-gradient(ellipse, rgba(124, 189, 75, 0.16), transparent 70%);
  pointer-events: none;
}
.hero-icon {
  width: 132px;
  height: 132px;
  border-radius: 28px;
  box-shadow: 0 18px 60px rgba(0, 0, 0, 0.55), 0 0 0 1px var(--line);
  margin-bottom: 32px;
}
.hero-title {
  font-size: 46px;
  font-weight: 900;
  letter-spacing: 0.01em;
  line-height: 1.2;
}
.hero-slogan {
  margin-top: 14px;
  font-size: 20px;
  font-weight: 700;
  color: var(--accent-soft);
}
.hero-intro {
  margin: 22px auto 0;
  max-width: 560px;
  color: var(--text-dim);
  font-size: 16px;
}
.hero-actions {
  margin-top: 36px;
  display: flex;
  gap: 14px;
  justify-content: center;
  flex-wrap: wrap;
}

@media (max-width: 640px) {
  .hero-title {
    font-size: 32px;
  }
  .hero-icon {
    width: 104px;
    height: 104px;
  }
}
</style>
