using MChub.Core.Module.Widgets;
using MChub.Core.Services.SystemResources;
using MChub.Localization;

using MChub.Module;
namespace MChub.Views.Widgets;

public sealed class GpuResourceWidget : ResourceWidgetBase
{
    public GpuResourceWidget(WidgetCellSize size) : base(size)
    {
        Title = "GPU";
        IconGlyph = "\ue636";
    }

    public override ResourceKind ResourceKind => ResourceKind.Gpu;

    protected override void OnUpdate(ResourceSnapshot snapshot)
    {
        if (snapshot.GpuUsage is { } usage)
        {
            PrimaryText = $"{usage:F1}%";
            Percentage = usage;
            ProgressValue = usage;
        }
        else
        {
            PrimaryText = "N/A";
            Percentage = 0;
            ProgressValue = 0;
        }

        SecondaryText = snapshot.GpuName ?? CommonLanguageManager.Instance.widgets_unavailable.CurrentValue();
    }
}