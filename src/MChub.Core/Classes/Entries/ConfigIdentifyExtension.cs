using MChub.Core.Classes.Config;
using MChub.Core.Minecraft.Classes;
using Tio.Avalonia.Standard.Modules.DiskIO;

namespace MChub.Core.Classes.Entries;

public class ConfigIdentifyExtension
{
    public static void MinecraftFolder(ConfigEntry entry)
    {
        var installableFolders = entry.MinecraftFolders.Where(IsInstallableFolder).ToList();
        if (installableFolders.Count == 0)
        {
            entry.DefaultMinecraftFolder = null;
            var defaultFolder = CreateDefaultMinecraftFolder();
            entry.MinecraftFolders.Insert(0, defaultFolder);
            installableFolders.Add(defaultFolder);
        }

        if (entry.DefaultMinecraftFolder == null ||
            !entry.MinecraftFolders.Contains(entry.DefaultMinecraftFolder) ||
            !IsInstallableFolder(entry.DefaultMinecraftFolder))
            entry.DefaultMinecraftFolder = installableFolders[0];
    }

    public static void Window(ConfigEntry entry)
    {
        if (entry.TabWindowHeight < 379)
            entry.TabWindowHeight = 710;
        if (entry.TabWindowWidth < 709)
            entry.TabWindowWidth = 1200;
        if (entry.AppScale < 0.49)
            entry.AppScale = 1;
    }

    private static bool IsInstallableFolder(MinecraftFolderEntry folder)
    {
        return folder.DetectedLayout.Kind == MinecraftFolderKind.MChubMc;
    }

    private static MinecraftFolderEntry CreateDefaultMinecraftFolder()
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "hub.code.MChub.minecraft");

        foreach (var directory in new[]
                 {
                     Path.Combine(path, "meta", "assets"),
                     Path.Combine(path, "meta", "libraries"),
                     Path.Combine(path, "meta", "natives"),
                     Path.Combine(path, "meta", "versions"),
                     Path.Combine(path, "instances"),
                     Path.Combine(path, "bedrock_instances")
                 })
            Helper.TryCreateFolder(directory);
        return new MinecraftFolderEntry
        {
            FolderName = "MChub MC",
            FolderPath = path,
            FolderKind = MinecraftFolderKind.MChubMc
        };
    }
}