namespace MChub.Core.Module.Ipc;

public enum MChubCommandKind
{
    DownloadVanilla,
    DownloadLoader,
    DownloadModpack,
    Launch,
    ShowMainWindow
}

public sealed class MChubCommand
{
    public MChubCommandKind Kind { get; set; }

    public string? Version { get; set; }

    public List<MChubLoaderSpec> Loaders { get; set; } = [];

    public string? Source { get; set; }

    public string? Provider { get; set; }

    public string? PackVersion { get; set; }

    public string? Folder { get; set; }

    public string? InstanceId { get; set; }

    public string? WorldFolder { get; set; }

    public string? ServerAddress { get; set; }

    public int? ServerPort { get; set; }
}

public sealed record MChubLoaderSpec(string Kind, string? Version);