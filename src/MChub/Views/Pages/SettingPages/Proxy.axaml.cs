using MChub.Core.Module.AggregatedSearch;
using MChub.Core.Services;
using MChub.ViewModels;

namespace MChub.Views.Pages.SettingPages;

[AggregatedSearchPage("pages_proxy", "pages_proxyPath", "Proxy")]
public partial class Proxy : Dsc
{
    public Proxy()
    {
        InitializeComponent();
        DataContext = this;
    }

    public object DefaultAgent => $"MChub/{AppVersionService.Instance.Version.VersionTitle}";
}