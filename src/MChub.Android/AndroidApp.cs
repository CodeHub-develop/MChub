using Android.App;
using Android.Runtime;
using Avalonia;
using Avalonia.Android;

namespace MChub.Mobile;

/// <summary>
/// Android 侧的应用入口。Avalonia 12 起 AppBuilder 在 Application 上配置，
/// Activity 只负责承载视图，因此这里持有构建与字体设置。
/// </summary>
[Application]
public class AndroidApp : AvaloniaAndroidApplication<MobileApp>
{
    public AndroidApp(nint javaReference, JniHandleOwnership transfer)
        : base(javaReference, transfer)
    {
    }

    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        => base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .LogToTrace();
}
