import { icons } from './icons.js'

export const site = {
  name: 'MChub',
  slogan: '少一点配置，多一点游戏',
  heroTitle: '你的 Minecraft，从这里出发',
  intro: '开源、跨平台的 Minecraft 启动器与实例管理器，同时支持 Java 版和基岩版，提供从游戏安装、账户登录到资源查找与文件整理的一体化体验。',

  /* ── 功能 ── */
  features: [
    {
      icon: 'gamepad',
      title: '游戏管理',
      desc: '查看、搜索、排序、收藏并启动游戏，列表里直接看最近游玩记录与时长；安装原版 Minecraft 与常用 Java 版加载器。',
    },
    {
      icon: 'user',
      title: '账户登录',
      desc: '支持离线账户、微软账户和第三方账户登录，一个入口管理你的所有身份。',
    },
    {
      icon: 'package',
      title: '资源安装',
      desc: '直接浏览 Modrinth 和 CurseForge，模组、整合包、资源包、光影、数据包、地图一键安装，文件自动归位。',
    },
    {
      icon: 'folder',
      title: '文件整理',
      desc: '集中查看游戏日志、存档、截图、设置与资源文件，模组、光影、存档一目了然。',
    },
    {
      icon: 'box',
      title: '投影材料 · 开发中',
      desc: '打开 .litematic 与 .nbt 文件预览结构，统计并导出所需的材料清单。',
    },
    {
      icon: 'layers',
      title: '基岩版支持',
      desc: 'Windows 支持 GDK、UWP 本体的下载安装启动，以及 DLL 模组、预加载和可配置鼠标锁；Linux 走 Proton 启动。',
    },
    {
      icon: 'terminal',
      title: '命令行调用',
      desc: '支持命令行参数与浏览器 sl:// 链接调用安装与启动，脚本化一切。',
    },
  ],

  /* ── 下载 ── */
  // 三条发布通道，version 与日期由 tools/fetch-release.mjs 生成到 releases.json
  channels: [
    { id: 'latest', name: '正式版' },
    { id: 'commit', name: 'commit 版' },
    { id: 'nightly', name: 'nightly 版' },
  ],
  // 每条通道的 GitHub 下载路径（AUR 除外）
  channelTag: {
    latest: 'latest',
    commit: 'publish-commit',
    nightly: 'publish-nightly',
  },
  platforms: [
    {
      icon: 'windows',
      name: 'Windows',
      sub: 'x64 · 10 / 11',
      assets: [
        { file: 'MChub.win.x64.installer.zip', label: '安装程序' },
        { file: 'MChub.win.x64.portable.zip', label: '便携版' },
      ],
    },
    {
      icon: 'apple',
      name: 'macOS',
      sub: 'Apple Silicon',
      assets: [
        { file: 'MChub.osx.mac.arm64.dmg', label: '磁盘映像' },
        { file: 'MChub.osx.mac.arm64.app.zip', label: '应用包' },
      ],
    },
    {
      icon: 'apple',
      name: 'macOS',
      sub: 'Intel',
      assets: [
        { file: 'MChub.osx.mac.x64.dmg', label: '磁盘映像' },
        { file: 'MChub.osx.mac.x64.app.zip', label: '应用包' },
      ],
    },
    {
      icon: 'linux',
      name: 'Linux',
      sub: 'x64',
      assets: [
        { file: 'MChub.linux.x64.AppImage', label: 'AppImage' },
        { file: 'MChub.linux.x64.deb', label: 'deb 包' },
        { file: 'MChub.linux.x64.rpm', label: 'rpm 包' },
      ],
    },
  ],
  aur: {
    latest: 'mchub-bin',
    commit: 'mchub-commit-bin',
    nightly: 'mchub-nightly-bin',
  },
  // 代理加速：国内访问 GitHub 下载慢时切到这个源
  proxy: 'https://gh-proxy.com/',
  macNote:
    'macOS 首次打开前，请先把 MChub.app 移到「应用程序」文件夹，再在终端运行：sudo xattr -rd com.apple.quarantine /Applications/MChub.app',

  /* ── 开源 ── */
  license: 'AGPL-3.0',
  github: 'https://github.com/CodeHub-develop/MChub',
  issues: 'https://github.com/CodeHub-develop/MChub/issues',

  /* ── QQ 群 ── */
  qq: {
    number: '545716736',
    url: 'https://qm.qq.com/q/iU5DvgYclq',
    qr: './qq-group-qrcode.png',
  },

  /* ── 页脚 ── */
  footer: {
    note: '由 CodeHub 组织维护 · 开源 · 跨平台',
  },
}

export default site
