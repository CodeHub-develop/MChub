using MChub.Core.Module.Initialize;

namespace MChub.Mobile.Services;

/// <summary>
/// 移动端复用 <c>MChub.Core</c> 的业务层，但桌面端的 UI 引导（MChub.Module.Initialize.Initializer）
/// 无法在移动端复用，因此在这里单独引导 Core 配置。
///
/// 引导失败时不抛出，而是记录原因交给设置页展示：移动端界面本身必须始终可用。
/// </summary>
public static class MobileBootstrap
{
    public static bool CoreReady { get; private set; }

    public static string? FailureReason { get; private set; }

    public static void InitializeCore()
    {
        try
        {
            Config.Initialize();
            CoreReady = true;
            FailureReason = null;
        }
        catch (Exception exception)
        {
            CoreReady = false;
            FailureReason = exception.Message;
        }
    }
}
