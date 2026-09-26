using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MChub.Core.Module.Initialize;
using MChub.Localization;
using MChub.Mobile.Services;
using MChub.Mobile.Views;

namespace MChub.Mobile;

// Android 隐式全局 using 引入了 Android.App，Application 会与 Avalonia.Application 冲突，故写全名。
public partial class MobileApp : Avalonia.Application
{
    public override void Initialize()
    {
        LocalizationInitializer.Initialize();
        LocalizationService.Register(CommonLanguageManager.Instance);
        LocalizationService.Register(AppLanguageManager.Instance);
        LocalizationService.Register(MobileLanguageManager.Instance);

        AvaloniaXamlLoader.Load(this);

        MobileBootstrap.InitializeCore();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is ISingleViewApplicationLifetime singleView)
            singleView.MainView = new MobileShellView();

        base.OnFrameworkInitializationCompleted();
    }
}
