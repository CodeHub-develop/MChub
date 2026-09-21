<script setup>
import { icons } from '../data/icons.js'
import { site } from '../data/site.js'
</script>

<template>
  <section id="open-source" class="section">
    <div class="section-head">
      <h2 class="section-title">自由且透明</h2>
      <p class="section-sub">由社区共同塑造，欢迎参与。</p>
    </div>

    <div class="cols">
      <div class="panel">
        <div class="panel-title">
          <span class="icon" v-html="icons.github"></span>
          开源
        </div>
        <p class="panel-text">
          MChub 以 <b>{{ site.license }}</b> 开源，源码完全公开。发现问题或有想法，欢迎到
          Issues 反馈，或直接贡献代码。
        </p>
        <div class="panel-actions">
          <a class="btn btn-ghost" :href="site.github" target="_blank" rel="noopener noreferrer">
            <span class="icon" v-html="icons.github"></span>
            查看仓库
          </a>
          <a class="btn btn-ghost" :href="site.issues" target="_blank" rel="noopener noreferrer">
            <span class="icon" v-html="icons.message"></span>
            反馈问题
          </a>
        </div>
      </div>

      <a class="panel qq" :href="site.qq.url" target="_blank" rel="noopener noreferrer">
        <div class="panel-title">
          <span class="icon" v-html="icons.users"></span>
          官方 QQ 群
        </div>
        <p class="panel-text">扫码或点击加入，一起聊聊 MChub。</p>
        <div class="qq-row">
          <img class="qq-qr" :src="site.qq.qr" alt="QQ 群二维码" />
          <div>
            <div class="qq-number">{{ site.qq.number }}</div>
            <div class="qq-hint">点击跳转加群</div>
          </div>
        </div>
      </a>
    </div>
  </section>
</template>

<style scoped>
.cols {
  display: grid;
  grid-template-columns: 1.4fr 1fr;
  gap: 20px;
  max-width: 900px;
  margin: 0 auto;
}
.panel {
  background: var(--panel);
  border: 1px solid var(--line);
  border-radius: var(--radius);
  padding: 28px;
}
.qq {
  transition: border-color 0.2s;
}
.qq:hover {
  border-color: var(--accent);
}
.panel-title {
  display: flex;
  align-items: center;
  gap: 10px;
  font-size: 18px;
  font-weight: 800;
  margin-bottom: 14px;
}
.panel-title .icon {
  color: var(--accent-soft);
  font-size: 20px;
}
.panel-text {
  color: var(--text-dim);
  font-size: 14px;
  margin-bottom: 20px;
}
.panel-text b {
  color: var(--text);
}
.panel-actions {
  display: flex;
  gap: 12px;
  flex-wrap: wrap;
}
.panel-actions .btn {
  font-size: 14px;
  padding: 10px 18px;
}

.qq-row {
  display: flex;
  align-items: center;
  gap: 18px;
}
.qq-qr {
  width: 96px;
  height: 96px;
  border-radius: 10px;
  border: 1px solid var(--line);
}
.qq-number {
  font-size: 26px;
  font-weight: 900;
  letter-spacing: 0.04em;
}
.qq-hint {
  color: var(--text-faint);
  font-size: 13px;
  margin-top: 4px;
}

@media (max-width: 720px) {
  .cols {
    grid-template-columns: 1fr;
  }
}
</style>
