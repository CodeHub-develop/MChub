<script setup>
import { icons } from '../data/icons.js'
import { site } from '../data/site.js'
</script>

<template>
  <section id="features" class="section">
    <div class="section-head">
      <h2 class="section-title">不止是启动游戏</h2>
      <p class="section-sub">把复杂留在幕后，一处管理全部实例。</p>
    </div>

    <div class="grid">
      <div v-for="(f, i) in site.features" :key="f.title" class="card">
        <div class="card-icon" :class="{ dev: f.title.includes('开发中') }">
          <span class="icon" v-html="icons[f.icon]"></span>
        </div>
        <h3 class="card-title">
          {{ f.title }}
          <span v-if="f.title.includes('开发中')" class="badge">开发中</span>
        </h3>
        <p class="card-desc">{{ f.desc }}</p>
      </div>
    </div>
  </section>
</template>

<style scoped>
.grid {
  display: grid;
  grid-template-columns: repeat(3, minmax(0, 1fr));
  gap: 18px;
}
.card {
  background: var(--panel);
  border: 1px solid var(--line);
  border-radius: var(--radius);
  padding: 26px 24px;
  transition: transform 0.2s ease, border-color 0.2s ease;
}
.card:hover {
  transform: translateY(-4px);
  border-color: var(--accent);
}
.card-icon {
  width: 46px;
  height: 46px;
  border-radius: 12px;
  background: rgba(124, 189, 75, 0.14);
  color: var(--accent-soft);
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 22px;
  margin-bottom: 16px;
}
.card-icon.dev {
  color: var(--text-faint);
  background: rgba(255, 255, 255, 0.05);
}
.card-title {
  font-size: 17px;
  font-weight: 700;
  margin-bottom: 8px;
  display: flex;
  align-items: center;
  gap: 8px;
}
.badge {
  font-size: 11px;
  font-weight: 600;
  color: var(--text-faint);
  background: rgba(255, 255, 255, 0.06);
  padding: 1px 8px;
  border-radius: 999px;
}
.card-desc {
  color: var(--text-dim);
  font-size: 14px;
}

@media (max-width: 900px) {
  .grid {
    grid-template-columns: repeat(2, minmax(0, 1fr));
  }
}
@media (max-width: 620px) {
  .grid {
    grid-template-columns: 1fr;
  }
}
</style>
