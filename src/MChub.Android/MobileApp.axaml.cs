using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MChub.Core.Module.Initialize;
using MChub.Localization;
using MChub.Mobile.Services;
using MChub.Mobile.Views;

namespace MChub.Mobile;

public partial class MobileApp : Application
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
