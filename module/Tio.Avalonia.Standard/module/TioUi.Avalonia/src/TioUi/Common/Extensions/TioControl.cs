using Avalonia.Controls;
using Avalonia.VisualTree;
using TioUi.Controls;

namespace TioUi.Common.Extensions;

public static class TioControl
{
    public static TopLevel GetTopLevel(this Control control)
    {
        return TopLevel.GetTopLevel(control);
    }

    public static TioWindow? TryGetTioWindow(this Control control)
    {
        return control.GetTopLevel() as TioWindow;
    }

    public static string? TryGetHostId(this Control control)
    {
        var topLevel = control.GetTopLevel();
        if (topLevel is IHostIdProvider hostProvider)
            return hostProvider.HostId;

        if (topLevel is TioWindow tioWindow)
            return tioWindow.HostId;

        if (control is TioView view)
            return view.HostId;
        var tioView = control.GetVisualAncestors().OfType<TioView>().FirstOrDefault();
        return tioView?.HostId;
    }
}