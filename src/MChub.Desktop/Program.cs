using System.Diagnostics;
using System.Text;
using Avalonia;
using MChub.Core.Module.Initialize;
using MChub.Core.Services.SystemResources;
using Tio.Avalonia.Standard.Modules.DiskIO;
#if DEBUG
using HotAvalonia;
#endif

namespace MChub.Desktop;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        // macOS SIP/AMFI-disabled workaround: must be the very first thing we do.
        // Installs a SIGBUS handler that re-enables JIT write access, preventing
        // crashes in both the .NET runtime (GC) and Java subprocesses.
        MacOSJitFixNative.Install();

        App.StartupTimestamp = Stopwatch.GetTimestamp();
        Console.OutputEncoding = Encoding.UTF8;

        if (MChubCliHeadless.IsHeadlessCommand(args))
            Logger.MinimumLevel = Logger.LogLevel.Fatal;

        LocalizationInitializer.Initialize();

        Logger.Info("MChub MC");
        Logger.Info(@"  ____                   _             _     __  __    ____ ");
        Logger.Info(@" |  _ \    ___    _ __  | |_    __ _  | |   |  \/  |  / ___|");
        Logger.Info(@" | |_) |  / _ \  | '__| | __|  / _` | | |   | |\/| | | |    ");
        Logger.Info(@" |  __/  | (_) | | |    | |_  | (_| | | |   | |  | | | |___ ");
        Logger.Info(@" |_|      \___/  |_|     \__|  \__,_| |_|   |_|  |_|  \____|");
        Logger.Info("");

        ExceptionHandlerSetup.Register();

        if (args is ["--memory-optimize"])
        {
            Environment.Exit(MemoryOptimizationService.OptimizeCurrentProcessContext());
            return;
        }

        if (MChubCliHeadless.TryRun(args, out var exitCode))
        {
            Environment.Exit(exitCode);
            return;
        }

        DebugConsole.ShowIfEnabled();

        if (!SingleInstanceGuard.TryAcquire())
        {
            SingleInstanceGuard.HandleSecondaryLaunch(args);
            return;
        }

        if (!PrimaryInstanceStartup.Run(args))
            return;

        try
        {
            BuildAvaloniaApp(args)
                .StartWithClassicDesktopLifetime(args);
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex);
            throw;
        }
    }

    private static AppBuilder BuildAvaloniaApp(string[] args)
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
#if WINDOWS
            .WithWindowsJumpList(args)
#endif
#if DEBUG
            .UseHotReload()
#endif
            .WithManagedSystemDialogs()
            .WithInterFont()
            .LogToTrace();
}