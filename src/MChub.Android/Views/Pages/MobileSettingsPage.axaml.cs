using Avalonia;
using Avalonia.Controls;
using MChub.Core.Const;
using MChub.Localization;
using MChub.Mobile.Services;

namespace MChub.Mobile.Views.Pages;

public partial class MobileSettingsPage : UserControl
{
    public MobileSettingsPage()
    {
        InitializeComponent();

        LanguageValue.Text = LocalizationService.CurrentCulture.Name;
        ThemeValue.Text = Avalonia.Application.Current?.RequestedThemeVariant?.ToString() ?? "-";
        StorageValue.Text = ConfigPath.UserDataRootPath;

        if (MobileBootstrap.CoreReady)
        {
            VersionValue.Text = Data.Instance.Version.VersionTitle;
        }
        else
        {
            VersionValue.Text = MobileLanguageManager.Instance.mobile_settingsStorageUnknown.CurrentValue();
            CoreStatusText.Text = MobileBootstrap.FailureReason;
            CoreStatusText.IsVisible = !string.IsNullOrWhiteSpace(MobileBootstrap.FailureReason);
        }
    }
}
