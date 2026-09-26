using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;

namespace MChub.Mobile;

[Activity(
    Label = "MChub",
    Theme = "@style/MChubTheme",
    Icon = "@drawable/mchub_icon",
    MainLauncher = true,
    // Minecraft Java 版是横屏游戏，直接锁横屏，避免启动后反复重建 Activity。
    ScreenOrientation = ScreenOrientation.Landscape,
    ConfigurationChanges = ConfigChanges.Orientation
        | ConfigChanges.ScreenSize
        | ConfigChanges.ScreenLayout
        | ConfigChanges.SmallestScreenSize
        | ConfigChanges.UiMode
        | ConfigChanges.Density
        | ConfigChanges.Keyboard
        | ConfigChanges.KeyboardHidden)]
public class MainActivity : AvaloniaMainActivity<MobileApp>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        => base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .LogToTrace();
}
