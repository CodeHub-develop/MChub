using System.Reflection;
using System.Text.Json;
using MChub.Core.Classes.Entries;
using MChub.Core.Json;
using MChub.Localization;
using Tio.Avalonia.Standard.Modules.DiskIO;

namespace MChub.Core.Services;

public sealed class AppVersionService
{
    private const string VersionResourceName = "MChub.Core.Assets.version-ci.txt";
    private static AppVersionService? _instance;

    private AppVersionService()
    {
        Version = LoadVersionInfo();
    }

    public static AppVersionService Instance => _instance ??= new AppVersionService();

    public CiVersionInfo Version { get; private set; }

    private static CiVersionInfo LoadVersionInfo()
    {
        Logger.Info(LogLanguageManager.Instance.appVersion_loadStart.CurrentValue());
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(VersionResourceName);
        if (stream is null)
        {
            Logger.Warning(LogLanguageManager.Instance.appVersion_embeddedNotFoundUseLocal.CurrentValue());
            return CreateLocalVersionInfo();
        }

        using var reader = new StreamReader(stream);
        var text = reader.ReadToEnd();
        var versionInfo = string.IsNullOrWhiteSpace(text)
            ? null
            : JsonSerializer.Deserialize<CiVersionInfo>(text, MChubJson.Options);
        Logger.Info(string.Format(LogLanguageManager.Instance.appVersion_loadComplete.CurrentValue(),
            versionInfo?.VersionTitle ?? "local-build", versionInfo?.Type ?? "dev"));
        return versionInfo ?? CreateLocalVersionInfo();
    }

    private static CiVersionInfo CreateLocalVersionInfo()
    {
        return new CiVersionInfo
        {
            Type = "dev",
            VersionTitle = "local-build"
        };
    }
}