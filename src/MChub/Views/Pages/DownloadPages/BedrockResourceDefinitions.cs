using MChub.Core.Minecraft.Models;
using MChub.Localization;

namespace MChub.Views.Pages.DownloadPages;

public static class BedrockResourceDefinitions
{
    private const int CurseForgeBedrockGameId = 78022;

    public static ResourceDefinition BehaviorPack { get; } =
        new(ResourceKind.BedrockBehaviorPack,
            CommonLanguageManager.Instance.bedrockResourceSearch_behaviorPack.CurrentValue(), string.Empty, null, true,
            false, false,
            CurseForgeBedrockGameId);

    public static ResourceDefinition ResourcePack { get; } =
        new(ResourceKind.BedrockResourcePack,
            CommonLanguageManager.Instance.bedrockResourceSearch_resourcePack.CurrentValue(), string.Empty, null, true,
            false, false,
            CurseForgeBedrockGameId);

    public static ResourceDefinition World { get; } =
        new(ResourceKind.BedrockWorld, CommonLanguageManager.Instance.bedrockResourceSearch_world.CurrentValue(),
            string.Empty, null, true, false, false, CurseForgeBedrockGameId);

    public static ResourceDefinition WorldTemplate { get; } =
        new(ResourceKind.BedrockWorldTemplate,
            CommonLanguageManager.Instance.bedrockResourceSearch_worldTemplate.CurrentValue(), string.Empty, null, true,
            false, false,
            CurseForgeBedrockGameId);
}