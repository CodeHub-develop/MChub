namespace MChub.Views.Pages.DownloadPages;

public interface ISearchPageViewModel
{
    string SearchText { get; set; }
    void ExecuteSearch();
    void RefreshContent();
}
