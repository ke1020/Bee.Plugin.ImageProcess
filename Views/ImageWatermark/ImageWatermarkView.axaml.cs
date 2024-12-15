using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using Bee.Plugin.ImageProcess.ViewModels;
using Ke.ImageProcess.Models.Watermark;

namespace Bee.Plugin.ImageProcess.Views;

public partial class ImageWatermarkView : UserControl
{
    private bool _isFilePickerOpen = false;

    public ImageWatermarkView()
    {
        InitializeComponent();
    }

    private void WatermarkMode_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is not ComboBox comboBox)
        {
            return;
        }

        if (comboBox.DataContext is not ImageWatermarkViewModel d)
        {
            return;
        }

        if (comboBox.SelectedValue is WatermarkMode mode)
        {
            d.OnWatermarkModeChanged(mode);
        }
    }

    private async void WatermarkImage_GotFocus(object? sender, GotFocusEventArgs e)
    {
        await OpenFolderAsync(sender);
    }

    private async Task OpenFolderAsync(object? sender)
    {
        if (_isFilePickerOpen || sender is not TextBox textBox)
        {
            return;
        }

        try
        {
            _isFilePickerOpen = true;

            var storageProvider = TopLevel.GetTopLevel(this)?.StorageProvider;
            if (storageProvider is null)
            {
                return;
            }


            var files = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                AllowMultiple = false,
                Title = "Select an Image File",
                FileTypeFilter = [FilePickerFileTypes.ImageAll]
            });

            // 如果用户选择了文件，则将文件路径设置到文本框中
            if (files?.Count > 0)
            {
                textBox.Text = files[0].TryGetLocalPath();
            }
        }
        finally
        {
            _isFilePickerOpen = false;
        }
    }
}