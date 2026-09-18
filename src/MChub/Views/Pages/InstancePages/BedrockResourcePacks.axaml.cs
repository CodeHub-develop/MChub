using Avalonia.Controls;
using MChub.Core.Minecraft.Classes;

namespace MChub.Views.Pages.InstancePages;

public partial class BedrockResourcePacks : UserControl, IDisposable
{
    public BedrockResourcePacks()
    {
        InitializeComponent();
    }

    public BedrockResourcePacks(MinecraftInstance instance) : this()
    {
        ResourcePacksContent.Content = new ResourcePacks(instance);
    }


    public void Dispose()
    {
        (ResourcePacksContent.Content as IDisposable)?.Dispose();
    }
}