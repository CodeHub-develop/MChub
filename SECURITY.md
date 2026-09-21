# 安全策略

## 报告安全问题

如果你发现了安全问题，请**不要**开公开 issue，改走仓库的 Security 页面私密上报
（GitHub → Security → Report a vulnerability），或通过 README 中的联系方式直接联系维护者。

## 凭据处理策略

本项目自 Fork 自上游项目起，就**不将任何密钥提交进仓库**。所有构建期凭据一律通过
**环境变量**注入，由构建过程写入程序集元数据；变量缺失时对应功能自动关闭。

| 环境变量 | 用途 | 缺失时的行为 |
| --- | --- | --- |
| `CURSEFORGE_API_KEY` | CurseForge 搜索与下载 | 仅 Modrinth 可用 |
| `MICROSOFT_CLIENT_ID` | Microsoft / Xbox 账号登录 | 该登录方式不可用 |
| `LITTLESKIN_CLIENT_ID` | LittleSkin 皮肤库同步 | 皮肤库同步不可用 |
| `GRAVITYCONE_UPTIME_API_KEY` | GravityCone 可用性检测 | 该检测不可用 |
| `PORTAL_TELEMETRY_API_KEY` / `PORTAL_TELEMETRY_URL` | 遥测上报 | 不上报 |
| `PRE_MC_KEY` / `REL_MC_KEY` | 基岩版 Preview / Release | 对应基岩版通道不可用 |

### 使用这些凭据即代表接受上游条款

- **CurseForge**：
  [CurseForge 3rd Party API Terms and Conditions](https://support.curseforge.com/en/support/solutions/articles/9000207405-curse-forge-3rd-party-api-terms-and-conditions)
- **Microsoft**：
  [Microsoft Identity Platform Terms of Use](https://docs.microsoft.com/en-us/legal/microsoft-identity-platform/terms-of-use)

### 四条硬规则

1. **每把 key 属于特定项目身份，不得跨项目复用。**
   上游签发的 key 与你所发行项目的品牌、用途是绑定的。
2. **Fork / 二次分发 / 改名发行，必须先替换为本项目自有的 key，或将其置空。**
   置空（`""`）后对应功能自动关闭，程序仍可正常构建与运行 —— 这是被支持的用法。
   沿用原项目的 key 而不替换，等于以他人身份使用其配额并承担其条款。
3. **不得将 key 用于启动器用途之外的任何场景**，也不得用于任何可能触发上游风控的行为。
4. 提交前自检：`git grep -nE '\$2a\$10\$|client_id\s*=\s*"?[0-9a-f]{8}-'` 应为空。


## 其它安全约定

- **OAuth 一律走平台官方流程**，客户端不接触、不存储用户密码。
- **不引入未审计的二进制依赖**；新增第三方二进制需在 PR 中说明来源与用途。
- **导入外部整合包 / 资源包 / mod 时给出信任提示**，不静默执行来源不明的脚本。
- 遥测（若启用）仅上报匿名运行信息，不包含账号凭据、路径等可识别信息。
