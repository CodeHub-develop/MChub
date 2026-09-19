using System.ComponentModel;
using Avalonia.Interactivity;
using MChub.Core.Const;
using MChub.Core.Minecraft.Classes;
using MChub.Localization;
using MChub.Styles;
using MChub.Views.Components.Operations.Account;
using MChub.Views.Components.Operations.Java;
using MChub.Views.Components.Operations.OpenFile;
using Tio.Avalonia.Standard.Modules.DiskIO;
using Tio.Avalonia.Standard.Tab.Gateway;
using TioUi.Common;
using TioUi.Controls;
using TioUi.Shared;
using NewMinecraftFolderViewModel = MChub.Views.Components.Operations.OpenFile.NewMinecraftFolderViewModel;

namespace MChub.Views;

public partial class OobeWindow : FAAppWindow
{
    private const int STEP_COUNT = 4;

    private static readonly SoftBackEaseOut DotsEasing = new() { Amplitude = 0.6 };

    private int _dotsAnimationToken;

    public OobeWindow()
    {
        InitializeComponent();
        DataContext = this;

        Loaded += (_, _) => { ThemeListBox.SelectedIndex = (int)Data.ConfigEntry.Theme; };
        ThemeListBox.SelectionChanged += (_, _) =>
        {
            if (ThemeListBox.SelectedIndex == -1) return;
            Data.ConfigEntry.Theme = (Theme)ThemeListBox.SelectedIndex;
        };

        GoToStep(0);
    }

    public Data Data => Data.Instance;

    public event Action? Completed;

    private void GoToStep(int step)
    {
        step = Math.Clamp(step, 0, STEP_COUNT - 1);
        Steps.SelectedIndex = step;
        BackButton.IsEnabled = step > 0;
        NextButton.IsVisible = step < STEP_COUNT - 1;
        FinishButton.IsVisible = step == STEP_COUNT - 1;
        StepTitle.Text = step switch
        {
            0 => CommonLanguageManager.Instance.oobe_stepTheme.CurrentValue(),
            1 => CommonLanguageManager.Instance.oobe_stepMinecraftFolder.CurrentValue(),
            2 => CommonLanguageManager.Instance.oobe_stepAccount.CurrentValue(),
            3 => CommonLanguageManager.Instance.oobe_stepJava.CurrentValue(),
            _ => string.Empty
        };
        UpdateStepDots(step);
    }

    private void UpdateStepDots(int step)
    {
        var dots = StepDots.Children;
        var count = dots.Count;
        for (var i = 0; i < count; i++)
            dots[i].Classes.Set("active", i == step);

        var fromWidth = new double[count];
        var fromOpacity = new double[count];
        var toWidth = new double[count];
        var toOpacity = new double[count];
        for (var i = 0; i < count; i++)
        {
            fromWidth[i] = double.IsNaN(dots[i].Width) ? 6 : dots[i].Width;
            fromOpacity[i] = dots[i].Opacity;
            toWidth[i] = i == step ? 18 : 6;
            toOpacity[i] = i == step ? 1 : 0.3;
        }

        var token = ++_dotsAnimationToken;
        if (!IsLoaded)
        {
            Apply(1);
            return;
        }

        TimeSpan? startTime = null;
        RequestAnimationFrame(Frame);
        return;

        void Frame(TimeSpan now)
        {
            if (token != _dotsAnimationToken) return;
            startTime ??= now;
            var progress = Math.Clamp((now - startTime.Value).TotalMilliseconds / 200.0, 0, 1);
            Apply(progress >= 1 ? 1 : DotsEasing.Ease(progress));
            if (progress < 1) RequestAnimationFrame(Frame);
        }

        void Apply(double eased)
        {
            for (var i = 0; i < count; i++)
            {
                dots[i].Width = fromWidth[i] + (toWidth[i] - fromWidth[i]) * eased;
                dots[i].Opacity = Math.Clamp(fromOpacity[i] + (toOpacity[i] - fromOpacity[i]) * eased, 0, 1);
            }
        }
    }

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        GoToStep(Steps.SelectedIndex - 1);
    }

    private void Next_OnClick(object? sender, RoutedEventArgs e)
    {
        GoToStep(Steps.SelectedIndex + 1);
    }

    private void Finish_OnClick(object? sender, RoutedEventArgs e)
    {
        FinishButton.IsEnabled = false;
        Completed?.Invoke();
    }

    private async void AddFolder_OnClick(object? sender, RoutedEventArgs e)
    {
        var options = new OverlayDialogOptions
        {
            Mode = DialogMode.None,
            Buttons = DialogButton.None,
            CanLightDismiss = false,
            CanDragMove = true,
            IsCloseButtonVisible = false,
            CanResize = false,
            VerticalOffset = 60,
            VerticalAnchor = VerticalPosition.Top
        };

        var result = await OverlayDialog
            .ShowCustomAsync<NewMinecraftFolder, NewMinecraftFolderViewModel, MinecraftFolderEntry>(
                new NewMinecraftFolderViewModel(Data.ConfigEntry.MinecraftFolders.Select(x
                    => x.FolderPath).ToList()), this.TryGetHostId(), options);

        if (result == null) return;
        Data.ConfigEntry.MinecraftFolders.Add(result);
    }

    private async void AddAccount_OnClick(object? sender, RoutedEventArgs e)
    {
        var result = await AddAccount.Main(this.TryGetHostId(), Data.ConfigEntry.AuthServers);
        if (result == null) return;
        foreach (var minecraftAccount in result.JavaAccounts) Data.ConfigEntry.MinecraftAccounts.Add(minecraftAccount);
        if (result.JavaAccounts.Count > 0)
            Data.ConfigEntry.UsingMinecraftMinecraftAccount = result.JavaAccounts[^1];
        if (result.BedrockAccount is { } bedrockAccount)
        {
            var existing = Data.ConfigEntry.BedrockAccounts.FirstOrDefault(item => item.Xuid == bedrockAccount.Xuid);
            if (existing != null) Data.ConfigEntry.BedrockAccounts.Remove(existing);
            Data.ConfigEntry.BedrockAccounts.Add(bedrockAccount);
            Data.ConfigEntry.UsingBedrockAccount = bedrockAccount;
        }
    }

    private async void ScanJava_OnClick(object? sender, RoutedEventArgs e)
    {
        SetJavaBusy(true);
        this.Notice(CommonLanguageManager.Instance.javaPage_scanning.CurrentValue());
        ShowJavaStatus(CommonLanguageManager.Instance.oobe_scanningJava.CurrentValue());
        try
        {
            var result = await JavaRuntimeOperations.ScanAndAddAsync(Data.ConfigEntry.JavaRuntimes);
            ShowJavaStatus(string.Format(CommonLanguageManager.Instance.javaPage_scanComplete.CurrentValue(),
                result.AddedCount, result.DuplicateCount));
        }
        catch (Exception ex)
        {
            ShowJavaStatus(string.Format(CommonLanguageManager.Instance.javaPage_scanFailed.CurrentValue(),
                ex.Message));
        }
        finally
        {
            SetJavaBusy(false);
        }
    }

    private async void AddJava_OnClick(object? sender, RoutedEventArgs e)
    {
        SetJavaBusy(true);
        try
        {
            var result = await JavaRuntimeOperations.AddFromPickerAsync(this, Data.ConfigEntry.JavaRuntimes);
            if (result == null) return;

            if (!result.IsValid)
            {
                ShowJavaStatus(CommonLanguageManager.Instance.javaPage_unrecognizedJava.CurrentValue());
                return;
            }

            ShowJavaStatus(result.IsDuplicate
                ? CommonLanguageManager.Instance.javaPage_javaDuplicate.CurrentValue()
                : string.Format(CommonLanguageManager.Instance.oobe_javaAdded.CurrentValue(),
                    result.JavaRuntime!.DisplayName));
        }
        catch (Exception ex)
        {
            ShowJavaStatus(string.Format(CommonLanguageManager.Instance.javaPage_addJavaFailed.CurrentValue(),
                ex.Message));
        }
        finally
        {
            SetJavaBusy(false);
        }
    }

    private void SetJavaBusy(bool isBusy)
    {
        ScanJavaButton.IsEnabled = !isBusy;
        AddJavaButton.IsEnabled = !isBusy;
    }

    private void ShowJavaStatus(string message)
    {
        JavaStatusText.Text = message;
        JavaStatusText.IsVisible = true;
    }
}