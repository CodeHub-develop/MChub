namespace TioUi.Controls;

/// <summary>
///     标记一个可以作为 OverlayDialog 宿主的顶层元素。
///     窗口基类（如 TioWindow / FAAppWindow 派生窗口）实现该接口后，
///     <see cref="Common.Extensions.TioControl.TryGetHostId"/> 即可返回其 HostId，
///     从而让 OverlayDialog / Dialog 无需强依赖具体的窗口类型。
/// </summary>
public interface IHostIdProvider
{
    string? HostId { get; set; }
}