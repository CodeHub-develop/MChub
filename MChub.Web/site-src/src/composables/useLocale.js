/**
 * 极简双语支持 —— 不引 i18n 库。
 *
 * 用法：
 *   - 站点配置（site.js）里能翻译的人类文案写成 `{ zh, en }` 对象，模板里 `t(value)` 取值。
 *   - 组件里写死的中文短文案用 `t('中文', 'English')` 传入英文即可。
 * 语言切换后，因 `t()` 读的是 `locale.value`，相关处会自动重渲染。
 */
import { ref } from 'vue'

export const LOCALES = [
  { code: 'zh', label: '中文', htmlLang: 'zh-CN' },
  { code: 'en', label: 'English', htmlLang: 'en' },
]

const STORAGE_KEY = 'mchub-site-locale'

function detect() {
  try {
    const saved = localStorage.getItem(STORAGE_KEY)
    if (saved && LOCALES.some((l) => l.code === saved)) return saved
  } catch {
    /* 无痕模式下 localStorage 抛异常，忽略即可 */
  }
  const lang = typeof navigator === 'undefined' ? '' : navigator.language || ''
  return String(lang).toLowerCase().startsWith('zh') ? 'zh' : 'en'
}

export const locale = ref(detect())

export function setLocale(code) {
  if (!LOCALES.some((l) => l.code === code)) return
  locale.value = code
  try {
    localStorage.setItem(STORAGE_KEY, code)
  } catch {
    /* 同上 */
  }
  const target = LOCALES.find((l) => l.code === code)
  if (typeof document !== 'undefined') {
    document.documentElement.setAttribute('lang', target.htmlLang)
  }
}

/** 两语言之间来回切 */
export function toggleLocale() {
  setLocale(locale.value === 'zh' ? 'en' : 'zh')
}

/**
 * 取当前语言文案。
 * 传入 `{ zh, en }` 对象 → 取对应语言；
 * 传入字符串 + 可选英文 → 英文态用 `en`（未提供则回退原文）。
 */
export function t(value, en) {
  if (value && typeof value === 'object' && !Array.isArray(value)) {
    if ('zh' in value || 'en' in value) {
      return value[locale.value] ?? value.zh ?? value.en ?? ''
    }
    return value
  }
  if (locale.value === 'en' && en !== undefined) return en
  return value
}

// 模块加载时同步一次 <html lang>
if (typeof document !== 'undefined') {
  const current = LOCALES.find((l) => l.code === locale.value)
  if (current) document.documentElement.setAttribute('lang', current.htmlLang)
}