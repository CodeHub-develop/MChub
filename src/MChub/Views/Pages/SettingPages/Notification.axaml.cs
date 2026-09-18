using Avalonia.Controls;
using MChub.Core.Module.AggregatedSearch;
using MChub.Localization;
using MChub.ViewModels;
using Tio.Avalonia.Standard.Tab.Gateway;
using TioUi.Common.Extensions;

namespace MChub.Views.Pages.SettingPages;

[AggregatedSearchPage("pages_notifications", "pages_notificationsPath", "Notification")]
public partial class Notification : Dsc
{
    public Notification()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        (sender as Control)!.GetTopLevel().Notice(CommonLanguageManager.Instance.notification_test.CurrentValue());
    }
}