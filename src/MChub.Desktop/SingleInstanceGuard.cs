using MChub.Core.Module.Ipc;
using MChub.Localization;
using Tio.Avalonia.Standard.Modules.DiskIO;

namespace MChub.Desktop;

internal static class SingleInstanceGuard
{
    private const string MutexName = "hub.code.MChub.Singleton";

    private const int ForwardAttempts = 4;
    private static Mutex? _mutex;

    public static bool TryAcquire()
    {
        _mutex = new Mutex(true, MutexName, out var createdNew);
        if (createdNew)
        {
            Logger.Info(LogLanguageManager.Instance.desktop_singleInstance_acquired.CurrentValue());
            return true;
        }

        try
        {
            if (_mutex.WaitOne(0))
            {
                Logger.Warning(LogLanguageManager.Instance.desktop_singleInstance_abandoned.CurrentValue());
                return true;
            }
        }
        catch (AbandonedMutexException)
        {
            Logger.Warning(LogLanguageManager.Instance.desktop_singleInstance_abandoned.CurrentValue());
            return true;
        }

        Logger.Info(LogLanguageManager.Instance.desktop_singleInstance_runningDetected.CurrentValue());
        return false;
    }

    public static void HandleSecondaryLaunch(string[] args)
    {
        if (PackagePathResolver.TryGetBedrockPackagePath(args, out var bedrockPath))
        {
            ForwardCommand(new MChubCommand { Kind = MChubCommandKind.DownloadModpack, Source = bedrockPath });
            return;
        }

        if (PackagePathResolver.TryGetJavaPackagePath(args, out var javaPath))
        {
            ForwardCommand(new MChubCommand { Kind = MChubCommandKind.DownloadModpack, Source = javaPath });
            return;
        }

#if WINDOWS
        if (WindowsJumpListService.TryForwardToRunningInstance(args))
            return;
#endif

        switch (MChubCommandParser.Parse(args, out var command, out var error))
        {
            case MChubCliParseStatus.Help:
                MChubCommandService.WriteConsole(MChubCommandParser.GetHeadlessUsageText());
                return;
            case MChubCliParseStatus.Error:
                MChubCommandService.WriteConsole(
                    string.Format(CommonLanguageManager.Instance.desktop_commandService_argumentError.CurrentValue(), error, Environment.NewLine, Environment.NewLine, MChubCommandParser.GetUsageText()));
                return;
            case MChubCliParseStatus.Command when command is not null:
                ForwardCommand(command);
                return;
            case MChubCliParseStatus.NotACommand:
            default:
                NotifyShowMainWindow();
                return;
        }
    }

    private static void ForwardCommand(MChubCommand command)
    {
        if (MChubCommandService.TryForwardToRunningInstance(command, ForwardAttempts))
        {
            MChubCommandService.WriteConsole(CommonLanguageManager.Instance.desktop_commandService_forwarded.CurrentValue());
            Logger.Info(string.Format(LogLanguageManager.Instance.desktop_singleInstance_forwardedWithKind.CurrentValue(), command.Kind));
        }
        else
        {
            Logger.Warning(LogLanguageManager.Instance.desktop_singleInstance_forwardFailed.CurrentValue());
        }
    }

    private static void NotifyShowMainWindow()
    {
        var showCommand = new MChubCommand { Kind = MChubCommandKind.ShowMainWindow };
        if (MChubCommandService.TryForwardToRunningInstance(showCommand, ForwardAttempts))
            Logger.Info(LogLanguageManager.Instance.desktop_singleInstance_notifyShowWindow.CurrentValue());
        else
            Logger.Warning(LogLanguageManager.Instance.desktop_singleInstance_notifyShowWindowFailed.CurrentValue());
    }
}