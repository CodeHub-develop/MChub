using Avalonia.Controls;
using Avalonia.Interactivity;
// Android 隐式全局 using 引入了 Android.Widget，Button 会与 Avalonia.Controls.Button 冲突。
using Button = Avalonia.Controls.Button;
using MChub.Core.Const;
using MChub.Core.Minecraft.Classes;
using MChub.Core.Minecraft.Instance;
using MChub.Localization;
using MChub.Mobile.Services;

namespace MChub.Mobile.Views.Pages;

public partial class MobileInstancesPage : UserControl
{
    public MobileInstancesPage()
    {
        InitializeComponent();
        InstanceList.ItemsSource = InstanceManager.Instance.Instances;
        Refresh();
    }

    private void Refresh_OnClick(object? sender, RoutedEventArgs e) => Refresh();

    private void Refresh()
    {
        if (!MobileBootstrap.CoreReady)
        {
            StatusText.Text = MobileBootstrap.FailureReason ??
                              MobileLanguageManager.Instance.mobile_instancesEmpty.CurrentValue();
            EmptyHint.IsVisible = true;
            return;
        }

        StatusText.Text = MobileLanguageManager.Instance.mobile_instancesScanning.CurrentValue();
        try
        {
            InstanceManager.Instance.RefreshAll(Data.ConfigEntry.MinecraftFolders);
        }
        catch (Exception exception)
        {
            StatusText.Text = exception.Message;
            EmptyHint.IsVisible = true;
            return;
        }

        StatusText.Text = string.Empty;
        EmptyHint.IsVisible = InstanceManager.Instance.Instances.Count == 0;
    }

    private void Launch_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button { DataContext: MinecraftInstance instance })
            return;

        // 移动端启动链路（进程内 JNI JVM + 图形翻译层）尚未接入，
        // 这里先把入口打通并如实反馈状态，运行时落地后替换为真实启动调用。
        StatusText.Text = $"{instance.InstanceName} · " +
                          MobileLanguageManager.Instance.mobile_instancesLaunchPending.CurrentValue();
    }
}
