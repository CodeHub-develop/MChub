using System.Runtime.InteropServices;
using MChub.Core.Module.AggregatedSearch;
using MChub.ViewModels;

namespace MChub.Views.Pages.SettingPages;

[AggregatedSearchPage("pages_advanced", "pages_advancedPath", "Advanced")]
public partial class Advanced : Dsc
{
    public Advanced()
    {
        InitializeComponent();
        DataContext = this;
    }

    public bool IsOverlaySupported => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
}