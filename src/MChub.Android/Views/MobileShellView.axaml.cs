using Avalonia.Controls;
using Avalonia.Interactivity;
using MChub.Mobile.Views.Pages;

namespace MChub.Mobile.Views;

public partial class MobileShellView : UserControl
{
    private readonly MobileInstancesPage _instancesPage = new();
    private readonly MobileSettingsPage _settingsPage = new();

    public MobileShellView()
    {
        InitializeComponent();
        ShowPage(_instancesPage, InstancesNavButton, SettingsNavButton);
    }

    private void InstancesNav_OnClick(object? sender, RoutedEventArgs e)
        => ShowPage(_instancesPage, InstancesNavButton, SettingsNavButton);

    private void SettingsNav_OnClick(object? sender, RoutedEventArgs e)
        => ShowPage(_settingsPage, SettingsNavButton, InstancesNavButton);

    /// <summary>
    /// 用 OreUI 的 primary / secondary 变体表达选中态，不额外自造样式。
    /// </summary>
    private void ShowPage(Control page, Button active, Button inactive)
    {
        PageHost.Content = page;
        SetVariant(active, true);
        SetVariant(inactive, false);
    }

    private static void SetVariant(Button button, bool active)
    {
        button.Classes.Remove("primary");
        button.Classes.Remove("secondary");
        button.Classes.Add(active ? "primary" : "secondary");
    }
}
