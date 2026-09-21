// 内联 SVG 图标。stroke 风格走 feather 设计，fill 图标（github）单独标注。
// 统一 viewBox 24x24，颜色由 CSS 的 currentColor / fill 控制。

const S = (attrs) => ({
  stroke: 'currentColor',
  'stroke-width': 2,
  'stroke-linecap': 'round',
  'stroke-linejoin': 'round',
  fill: 'none',
  ...attrs,
})

export const icons = {
  // —— 品牌 / 通用 ——
  github: `<svg viewBox="0 0 24 24" width="1em" height="1em" fill="currentColor"><path d="M12 .297c-6.63 0-12 5.373-12 12 0 5.303 3.438 9.8 8.205 11.385.6.113.82-.258.82-.577 0-.285-.01-1.04-.015-2.04-3.338.724-4.042-1.61-4.042-1.61C4.422 18.07 3.633 17.7 3.633 17.7c-1.087-.744.084-.729.084-.729 1.205.084 1.838 1.236 1.838 1.236 1.07 1.835 2.809 1.305 3.495.998.108-.776.417-1.305.76-1.605-2.665-.3-5.466-1.332-5.466-5.93 0-1.31.465-2.38 1.235-3.22-.135-.303-.54-1.523.105-3.176 0 0 1.005-.322 3.3 1.23.96-.267 1.98-.399 3-.405 1.02.006 2.04.138 3 .405 2.28-1.552 3.285-1.23 3.285-1.23.645 1.653.24 2.873.12 3.176.765.84 1.23 1.91 1.23 3.22 0 4.61-2.805 5.625-5.475 5.92.42.36.81 1.096.81 2.22 0 1.606-.015 2.896-.015 3.286 0 .315.21.69.825.57C20.565 22.092 24 17.592 24 12.297c0-6.627-5.373-12-12-12"/></svg>`,

  download: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"/><polyline points="7 10 12 15 17 10"/><line x1="12" y1="15" x2="12" y2="3"/></svg>`,

  arrowRight: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><line x1="5" y1="12" x2="19" y2="12"/><polyline points="12 5 19 12 12 19"/></svg>`,

  external: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><path d="M18 13v6a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V8a2 2 0 0 1 2-2h6"/><polyline points="15 3 21 3 21 9"/><line x1="10" y1="14" x2="21" y2="3"/></svg>`,

  star: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><polygon points="12 2 15.09 8.26 22 9.27 17 14.14 18.18 21.02 12 17.77 5.82 21.02 7 14.14 2 9.27 8.91 8.26 12 2"/></svg>`,

  // —— 功能 ——
  gamepad: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><line x1="6" y1="12" x2="10" y2="12"/><line x1="8" y1="10" x2="8" y2="14"/><line x1="15" y1="12.5" x2="15.01" y2="12.5"/><line x1="18" y1="10.5" x2="18.01" y2="10.5"/><path d="M17.32 5H6.68a4 4 0 0 0-3.978 3.59c-.006.052-.01.101-.017.152C2.604 9.416 2 14.456 2 16a3 3 0 0 0 3 3c1 0 1.5-.5 2-1l1.414-1.414A2 2 0 0 1 9.828 16h4.344a2 2 0 0 1 1.414.586L17 18c.5.5 1 1 2 1a3 3 0 0 0 3-3c0-1.545-.604-6.584-.685-7.258-.007-.05-.011-.1-.017-.151A4 4 0 0 0 17.32 5z"/></svg>`,

  user: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"/><circle cx="12" cy="7" r="4"/></svg>`,

  package: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><path d="M21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16z"/><polyline points="3.27 6.96 12 12.01 20.73 6.96"/><line x1="12" y1="22.08" x2="12" y2="12"/></svg>`,

  folder: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><path d="M22 19a2 2 0 0 1-2 2H4a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h5l2 3h9a2 2 0 0 1 2 2z"/></svg>`,

  box: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><path d="M21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16z"/><polyline points="3.27 6.96 12 12.01 20.73 6.96"/><line x1="12" y1="22.08" x2="12" y2="12"/></svg>`,

  layers: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><polygon points="12 2 2 7 12 12 22 7 12 2"/><polyline points="2 17 12 22 22 17"/><polyline points="2 12 12 17 22 12"/></svg>`,

  terminal: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><polyline points="4 17 10 11 4 5"/><line x1="12" y1="19" x2="20" y2="19"/></svg>`,

  users: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M23 21v-2a4 4 0 0 0-3-3.87"/><path d="M16 3.13a4 4 0 0 1 0 7.75"/></svg>`,

  message: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><path d="M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z"/></svg>`,

  // —— 平台（fill）——
  windows: `<svg viewBox="0 0 24 24" width="1em" height="1em" fill="currentColor"><path d="M0 3.449L9.75 2.1v9.451H0zM10.949 2.1L24 0v11.4H10.949zM0 12.6h9.75v9.451L0 20.699zM10.949 12.6H24V24l-12.9-1.801z"/></svg>`,

  apple: `<svg viewBox="0 0 24 24" width="1em" height="1em" fill="currentColor"><path d="M12.152 6.896c-.948 0-2.415-1.078-3.96-1.04-2.04.027-3.91 1.183-4.961 3.014-2.117 3.675-.546 9.103 1.519 12.09 1.013 1.454 2.208 3.09 3.792 3.039 1.52-.065 2.09-.987 3.935-.987 1.831 0 2.35.987 3.96.948 1.637-.026 2.676-1.48 3.676-2.948 1.156-1.688 1.636-3.325 1.662-3.415-.039-.013-3.182-1.221-3.22-4.857-.026-3.04 2.48-4.494 2.597-4.559-1.429-2.09-3.623-2.324-4.39-2.376-2-.156-3.675 1.09-4.61 1.09zM15.53 3.83c.843-1.012 1.4-2.427 1.245-3.83-1.207.052-2.662.805-3.532 1.818-.78.896-1.454 2.338-1.273 3.714 1.338.104 2.715-.688 3.559-1.701"/></svg>`,

  linux: `<svg viewBox="0 0 24 24" width="1em" height="1em" ${Object.entries(S()).map(([k, v]) => `${k}="${v}"`).join(' ')}><path d="M12 2v4"/><path d="M12 6c-3 0-5 2-5 5 0 1.5.5 2.5 1 3.5L7 19c0 1 .5 1.5 1.5 1.5S10 20 10 19l.5-3"/><path d="M12 6c3 0 5 2 5 5 0 1.5-.5 2.5-1 3.5L17 19c0 1-.5 1.5-1.5 1.5S14 20 14 19l-.5-3"/><path d="M12 11v3"/><path d="M10 14h4"/><path d="M12 17c-1.5 0-2.5 1-3 2h6c-.5-1-1.5-2-3-2z"/></svg>`,
}
