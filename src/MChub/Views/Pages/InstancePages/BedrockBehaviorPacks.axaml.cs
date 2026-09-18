using Avalonia.Controls;
using MChub.Core.Minecraft.Classes;

namespace MChub.Views.Pages.InstancePages;

public partial class BedrockBehaviorPacks : UserControl, IDisposable
{
    public BedrockBehaviorPacks()
    {
        InitializeComponent();
    }

    public BedrockBehaviorPacks(MinecraftInstance instance) : this()
    {
        BehaviorPacksContent.Content = new BehaviorPacks(instance);
    }


    public void Dispose()
    {
        (BehaviorPacksContent.Content as IDisposable)?.Dispose();
    }
}