using Avalonia.Controls;
using MChub.Core.Minecraft.Models;
using MChub.Core.Minecraft.Services;

namespace MChub.Views.Pages.DownloadPages;

public partial class BedrockResourceSearchPage : ResourceSearchPageBase
{
    protected BedrockResourceSearchPage(ResourceDefinition definition)
    {
        InitializeComponent();
        DataContext = new BedrockResourceSearchViewModel(definition);
        Loaded += async (_, _) => await ((BedrockResourceSearchViewModel)DataContext).InitializeAsync();
    }

    public BedrockResourceSearchPage() : this(BedrockResourceDefinitions.BehaviorPack)
    {
    }

    protected override FavoriteEdition FavoriteEdition => FavoriteEdition.Bedrock;

    protected override Task QuickDownloadAsync(TopLevel topLevel, JavaResourceSearchResultItem item)
    {
        return BedrockResourceDownload.QuickDownloadAsync(topLevel, item.Target);
    }
}

public sealed class BedrockBehaviorPackSearchPage()
    : BedrockResourceSearchPage(BedrockResourceDefinitions.BehaviorPack);

public sealed class BedrockResourcePackSearchPage()
    : BedrockResourceSearchPage(BedrockResourceDefinitions.ResourcePack);

public sealed class BedrockWorldSearchPage() : BedrockResourceSearchPage(BedrockResourceDefinitions.World);

public sealed class BedrockWorldTemplateSearchPage()
    : BedrockResourceSearchPage(BedrockResourceDefinitions.WorldTemplate);
