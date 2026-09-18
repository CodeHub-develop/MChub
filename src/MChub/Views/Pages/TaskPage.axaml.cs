using Avalonia.Media;
using MChub.Core.Module.AggregatedSearch;
using MChub.Localization;
using MChub.ViewModels;
using Tio.Avalonia.Standard.Tab.Entries;
using Tio.Avalonia.Standard.Tab.Interface;

using MChub.Module;
namespace MChub.Views.Pages;

[AggregatedSearchPage("pages_tasks", "pages_tasksPath", "Task")]
public partial class TaskPage : Dsc, ITioTabPage
{
    public TaskPage()
    {
        InitializeComponent();
        DataContext = this;
    }

    public PageInfo PageInfo { get; init; } = new()
    {
        Title = CommonLanguageManager.Instance.titleBar_tasks.CurrentValue(),
        IconGlyph = "\ue62a", IconFont = IconResources.FontFamilyName
    };

    public TabEntry HostTab { get; set; }

    public void OnClose()
    {
        DataContext = null;
    }
}