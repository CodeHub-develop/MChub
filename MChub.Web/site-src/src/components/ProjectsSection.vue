<script setup>
import { onMounted, onUnmounted } from 'vue'
import { site } from '../data/site.js'
import { t } from '../composables/useLocale.js'

/* 卡片滚进视口才淡入上移。直接在 mounted 里查 DOM ——
   列表是静态数据、挂载时已经渲染完，不需要用 ref 回调一个个收集 */
let io = null

onMounted(() => {
  const cards = document.querySelectorAll('.reveal-card')
  if (!cards.length) return

  io = new IntersectionObserver(
    (entries) => {
      entries.forEach((entry) => {
        if (entry.isIntersecting) {
          entry.target.classList.add('animate-in')
          io.unobserve(entry.target)
        }
      })
    },
    { threshold: 0.1 },
  )

  cards.forEach((el) => io.observe(el))
})

onUnmounted(() => {
  io?.disconnect()
})
</script>

<template>
  <!-- 功能：直接占满首屏往下滚动就能看到 -->
  <section id="feature" class="about">
    <h2 class="section-title">{{ t(site.about.featuresTitle) }}</h2>
    <div class="card-grid">
      <div v-for="f in site.features" :key="f.title.zh" class="reveal-card">
        <h3 class="item-title">{{ t(f.title) }}</h3>
        <p class="item-desc">{{ t(f.desc) }}</p>
      </div>
    </div>
  </section>

  <!-- 关于 -->
  <section id="about" class="about">
    <h2 class="section-title">{{ t(site.about.title) }}</h2>
    <div class="intro">
      <p v-for="p in t(site.about.paragraphs)" :key="p">{{ p }}</p>
    </div>
  </section>

  <!-- 下载 -->
  <section id="download" class="about">
    <h2 class="section-title">{{ t(site.about.downloadTitle) }}</h2>

    <div class="card-grid">
      <div v-for="plat in site.platforms" :key="plat.name + plat.sub" class="reveal-card">
        <h3 class="item-title">{{ plat.name }}</h3>
        <p class="item-sub">{{ plat.sub }}</p>
        <div class="download-links">
          <a
            v-for="a in plat.assets"
            :key="a.file"
            class="dl-link"
            :href="`${site.downloadBase}/${a.file}`"
            target="_blank"
            rel="noopener noreferrer"
          >
            {{ t(a.label) }}
          </a>
        </div>
      </div>
    </div>

    <p class="more">
      <a :href="site.releasesUrl" target="_blank" rel="noopener noreferrer">
        {{ t({ zh: '在 GitHub 上看全部版本', en: 'See all releases on GitHub' }) }} →
      </a>
    </p>
  </section>
</template>

<style scoped>
.about {
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 24px 140px;
}

.section-title {
  font-size: 36px;
  margin-top: 64px;
  margin-bottom: 28px;
  color: #fff;
}

.intro {
  max-width: 760px;
  line-height: 1.75;
  color: #ffffffb3;
}

.intro p + p {
  margin-top: 0.9rem;
}

/* ── 卡片网格（功能 / 下载平台共用） ── */
.card-grid {
  display: grid;
  grid-template-columns: repeat(1, minmax(0, 1fr));
  gap: 18px;
}

.reveal-card {
  display: block;
  padding: 20px 22px;
  border-radius: 12px;
  background-color: #ffffff1a;
  color: #fff;
  /* 收起来的状态，等 IntersectionObserver 加 .animate-in */
  opacity: 0;
  transform: translateY(16px);
  transition:
    opacity 0.7s ease-out,
    transform 0.7s ease-out,
    background-color 0.3s ease;
}

.reveal-card.animate-in {
  opacity: 1;
  transform: translateY(0);
}

.reveal-card:hover {
  background-color: #ffffff26;
  transform: translateY(-4px);
}

.item-title {
  font-size: 1.125rem;
  font-weight: 700;
  margin-bottom: 0.5rem;
  word-break: break-word;
}

.item-sub {
  font-size: 0.85rem;
  color: #ffffff80;
  margin-bottom: 0.75rem;
}

.item-desc {
  font-size: 0.875rem;
  line-height: 1.6;
  color: #fff9;
  display: -webkit-box;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
  overflow: hidden;
}

/* ── 下载链接 ── */
.download-links {
  display: flex;
  flex-wrap: wrap;
  gap: 8px;
  margin-top: 6px;
}

.dl-link {
  display: inline-block;
  padding: 5px 12px;
  border-radius: 999px;
  font-size: 0.8rem;
  color: #fff;
  background: #ffffff14;
  border: 1px solid #ffffff2e;
  transition: all 0.25s ease;
}

.dl-link:hover {
  background: #ffffff2e;
  border-color: #ffffff59;
}

.more {
  margin-top: 36px;
  text-align: right;
}

.more a {
  font-size: 0.9rem;
  color: #ffffffb3;
  border-bottom: 1px solid #ffffff40;
  padding-bottom: 2px;
  transition: color 0.25s ease;
}

.more a:hover {
  color: #fff;
  border-color: #fff;
}

@media (min-width: 768px) {
  .card-grid {
    grid-template-columns: repeat(2, minmax(0, 1fr));
  }
}

@media (min-width: 1200px) {
  .card-grid {
    grid-template-columns: repeat(3, minmax(0, 1fr));
  }
}

@media (max-width: 648px) {
  .section-title {
    font-size: 28px;
    margin-top: 44px;
  }

  .about {
    padding-bottom: 90px;
  }

  .more {
    text-align: left;
  }
}
</style>