<script setup>
import { ref, computed } from 'vue'
import { icons } from '../data/icons.js'
import { site } from '../data/site.js'
// 由 tools/fetch-release.mjs 生成：各通道的版本号与发布日期
import releases from '../data/releases.json'

// 默认选 commit 版——当前唯一有发布（latest / nightly 的 release 还没发过）
const channel = ref('commit')
const useProxy = ref(false)

const channelInfo = computed(() => releases.channels[channel.value] || {})

function ghBase(ch) {
  const tag = site.channelTag[ch]
  return ch === 'latest'
    ? `https://github.com/CodeHub-develop/MChub/releases/latest/download/`
    : `https://github.com/CodeHub-develop/MChub/releases/download/${tag}/`
}

function downloadUrl(asset) {
  const base = ghBase(channel.value) + asset
  return useProxy.value ? site.proxy + base : base
}

function aurUrl(pkg) {
  return `https://aur.archlinux.org/packages/${pkg}`
}

function fmtDate(iso) {
  if (!iso) return ''
  return iso.slice(0, 10)
}
</script>

<template>
  <section id="download" class="section download">
    <div class="section-head">
      <h2 class="section-title">下载 MChub</h2>
      <p class="section-sub">选择你的平台与版本，随时开始。</p>
    </div>

    <div class="download-box">
      <!-- 通道切换 -->
      <div class="channels">
        <button
          v-for="c in site.channels"
          :key="c.id"
          class="channel"
          :class="{ active: channel === c.id }"
          @click="channel = c.id"
        >
          <span class="channel-name">{{ c.name }}</span>
          <span class="channel-ver">{{ releases.channels[c.id]?.tag || '暂未发布' }}</span>
        </button>
      </div>

      <div class="channel-meta">
        <span v-if="channelInfo.tag" class="meta-item">
          版本 <b>{{ channelInfo.tag }}</b>
        </span>
        <span v-if="channelInfo.publishedAt" class="meta-item">
          发布于 {{ fmtDate(channelInfo.publishedAt) }}
        </span>
        <label class="proxy-toggle">
          <input type="checkbox" v-model="useProxy" />
          <span>代理加速</span>
          <span class="proxy-hint">（国内下载慢时开启，走 gh-proxy 镜像）</span>
        </label>
      </div>

      <!-- 平台列表 -->
      <div class="platforms" v-if="channelInfo.tag">
        <div v-for="p in site.platforms" :key="p.name + p.sub" class="platform">
          <div class="platform-head">
            <span class="platform-icon" :class="p.icon" v-html="icons[p.icon]"></span>
            <div>
              <div class="platform-name">{{ p.name }}</div>
              <div class="platform-sub">{{ p.sub }}</div>
            </div>
          </div>
          <div class="platform-links">
            <a
              v-for="a in p.assets"
              :key="a.file"
              class="asset"
              :href="downloadUrl(a.file)"
              target="_blank"
              rel="noopener noreferrer"
            >
              <span class="icon" v-html="icons.download"></span>
              {{ a.label }}
            </a>
          </div>
        </div>

        <!-- AUR -->
        <div class="platform">
          <div class="platform-head">
            <span class="platform-icon linux" v-html="icons.terminal"></span>
            <div>
              <div class="platform-name">Arch Linux</div>
              <div class="platform-sub">AUR</div>
            </div>
          </div>
          <div class="platform-links">
            <a class="asset" :href="aurUrl(site.aur[channel])" target="_blank" rel="noopener noreferrer">
              <span class="icon" v-html="icons.external"></span>
              {{ site.aur[channel] }}
            </a>
          </div>
        </div>
      </div>

      <div v-else class="empty">
        <p>该版本暂未发布</p>
        <span>可切换到「commit 版」获取最新构建。</span>
      </div>

      <p class="mac-note" v-if="channel !== 'nightly'">{{ site.macNote }}</p>
    </div>
  </section>
</template>

<style scoped>
.download-box {
  max-width: 900px;
  margin: 0 auto;
  background: var(--panel);
  border: 1px solid var(--line);
  border-radius: 18px;
  padding: 28px;
}

.channels {
  display: flex;
  gap: 10px;
  flex-wrap: wrap;
}
.channel {
  flex: 1;
  min-width: 120px;
  padding: 12px 16px;
  border-radius: 12px;
  background: var(--bg-2);
  border: 1px solid var(--line);
  text-align: left;
  transition: border-color 0.2s, background-color 0.2s;
}
.channel.active {
  border-color: var(--accent);
  background: rgba(124, 189, 75, 0.1);
}
.channel-name {
  display: block;
  font-weight: 700;
  font-size: 15px;
}
.channel-ver {
  display: block;
  font-size: 12px;
  color: var(--text-faint);
  margin-top: 2px;
}

.channel-meta {
  display: flex;
  align-items: center;
  gap: 18px;
  flex-wrap: wrap;
  margin-top: 18px;
  padding: 12px 4px;
  color: var(--text-dim);
  font-size: 13px;
  border-bottom: 1px solid var(--line);
}
.meta-item b {
  color: var(--accent-soft);
}
.proxy-toggle {
  margin-left: auto;
  display: flex;
  align-items: center;
  gap: 7px;
  cursor: pointer;
  user-select: none;
}
.proxy-toggle input {
  accent-color: var(--accent);
  width: 16px;
  height: 16px;
}
.proxy-hint {
  color: var(--text-faint);
  font-size: 12px;
}

.platforms {
  margin-top: 12px;
}
.platform {
  display: flex;
  align-items: center;
  gap: 24px;
  padding: 18px 6px;
  border-bottom: 1px solid var(--line);
}
.platform:last-child {
  border-bottom: none;
}
.platform-head {
  display: flex;
  align-items: center;
  gap: 14px;
  width: 200px;
  flex-shrink: 0;
}
.platform-icon {
  font-size: 24px;
  color: var(--text);
  display: inline-flex;
}
.platform-icon.windows,
.platform-icon.apple {
  font-size: 26px;
}
.platform-name {
  font-weight: 700;
  font-size: 15px;
}
.platform-sub {
  font-size: 12px;
  color: var(--text-faint);
}
.platform-links {
  display: flex;
  gap: 10px;
  flex-wrap: wrap;
}
.asset {
  display: inline-flex;
  align-items: center;
  gap: 8px;
  padding: 9px 16px;
  border-radius: 10px;
  background: var(--bg-2);
  border: 1px solid var(--line);
  font-size: 14px;
  font-weight: 600;
  transition: border-color 0.2s, color 0.2s;
}
.asset:hover {
  border-color: var(--accent);
  color: var(--accent-soft);
}
.asset .icon {
  font-size: 15px;
}

.mac-note {
  margin-top: 18px;
  padding: 14px 18px;
  border-radius: 10px;
  background: rgba(255, 255, 255, 0.04);
  border: 1px dashed var(--line);
  color: var(--text-dim);
  font-size: 13px;
  line-height: 1.7;
}

.empty {
  text-align: center;
  padding: 48px 20px;
  color: var(--text-faint);
}
.empty p {
  font-size: 16px;
  font-weight: 700;
  color: var(--text-dim);
  margin-bottom: 6px;
}
.empty span {
  font-size: 13px;
}

@media (max-width: 640px) {
  .platform {
    flex-direction: column;
    align-items: flex-start;
    gap: 14px;
  }
  .platform-head {
    width: auto;
  }
}
</style>
