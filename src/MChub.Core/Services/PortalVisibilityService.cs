using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using MChub.Core.Classes;
using MChub.Core.Const;
using MChub.Core.Module.Initialize;

namespace MChub.Core.Services;

public static class MChubVisibilityService
{
    private static int _runningGames;
    private static MChubVisibleMode _appliedMode = MChubVisibleMode.NoOperation;
    private static readonly List<Window> _hiddenWindows = [];
    private static readonly List<(Window Window, WindowState State)> _minimizedWindows = [];

    public static void OnGameStarted(MChubVisibleMode mode)
    {
        Dispatcher.UIThread.Post(() =>
        {
            _runningGames++;
            if (_runningGames > 1)
                return;

            _appliedMode = mode;
            switch (_appliedMode)
            {
                case MChubVisibleMode.QuitAfterLaunch:
                    Shutdown();
                    break;
                case MChubVisibleMode.HiddenAfterLaunchAndReopen:
                    HideAllWindows();
                    break;
                case MChubVisibleMode.MinimizedAfterLaunch:
                case MChubVisibleMode.MinimizedAfterLaunchAndRestore:
                    MinimizeAllWindows();
                    break;
            }
        });
    }

    public static void OnGameExited()
    {
        Dispatcher.UIThread.Post(() =>
        {
            _runningGames = Math.Max(0, _runningGames - 1);
            if (_runningGames > 0)
                return;

            switch (_appliedMode)
            {
                case MChubVisibleMode.HiddenAfterLaunchAndReopen:
                    ShowHiddenWindows();
                    break;
                case MChubVisibleMode.MinimizedAfterLaunchAndRestore:
                    RestoreMinimizedWindows();
                    break;
                case MChubVisibleMode.MinimizedAfterLaunch:
                    _minimizedWindows.Clear();
                    break;
            }

            _appliedMode = MChubVisibleMode.NoOperation;
        });
    }

    private static IEnumerable<Window> GetWindows()
    {
        return Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.Windows
            : [];
    }

    private static void HideAllWindows()
    {
        _hiddenWindows.Clear();
        foreach (var window in GetWindows())
        {
            if (!window.IsVisible)
                continue;
            _hiddenWindows.Add(window);
            window.Hide();
        }
    }

    private static void ShowHiddenWindows()
    {
        foreach (var window in _hiddenWindows)
            try
            {
                window.Show();
                window.Activate();
            }
            catch
            {
            }

        _hiddenWindows.Clear();
    }

    private static void MinimizeAllWindows()
    {
        _minimizedWindows.Clear();
        foreach (var window in GetWindows())
        {
            if (!window.IsVisible || window.WindowState == WindowState.Minimized)
                continue;
            _minimizedWindows.Add((window, window.WindowState));
            window.WindowState = WindowState.Minimized;
        }
    }

    private static void RestoreMinimizedWindows()
    {
        foreach (var (window, state) in _minimizedWindows)
            try
            {
                window.WindowState = state;
                window.Activate();
            }
            catch
            {
            }

        _minimizedWindows.Clear();
    }

    private static void Shutdown()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            ConfigSaver.FlushConfig();
            desktop.Shutdown();
        }
    }
}