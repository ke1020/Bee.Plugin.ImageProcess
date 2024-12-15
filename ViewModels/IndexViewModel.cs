using Avalonia.Controls;
using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Views;
using Ke.Bee.Localization.Localizer.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Bee.Plugin.ImageProcess.ViewModels;

public partial class IndexViewModel : WorkspaceViewModel
{
    private static readonly string[] _tabLocalHeaders = [
        "Bee.Plugin.ImageProcess.Convert",
        "Bee.Plugin.ImageProcess.Scale",
        "Bee.Plugin.ImageProcess.Watermark"
    ];
    /// <summary>
    /// 标签页
    /// </summary>
    public List<TabItem> Tabs => _tabLocalHeaders.Select((x, i) => new TabItem { TabIndex = i, Header = _l[x] }).ToList();

    private TabItem? _selectedTab;
    /// <summary>
    /// 选中项
    /// </summary>
    public TabItem SelectedTab
    {
        get => _selectedTab ?? Tabs[0];
        set
        {
            switch (value.TabIndex)
            {
                case 0:
                    _imageConvertV ??= _serviceProvider.GetService<ImageConvertViewModel>()!;
                    value.DataContext = _imageConvertV;
                    value.Content = new ImageConvertView { DataContext = _imageConvertV };
                    break;
                case 1:
                    _imageScaleV ??= _serviceProvider.GetService<ImageScaleViewModel>()!;
                    value.DataContext = _imageScaleV;
                    value.Content = new ImageScaleView { DataContext = _imageScaleV };
                    break;
                case 2:
                    _imageWatermarkV ??= _serviceProvider.GetService<ImageWatermarkViewModel>()!;
                    value.DataContext = _imageWatermarkV;
                    value.Content = new ImageWatermarkView { DataContext = _imageWatermarkV };
                    break;
            }
            SetProperty(ref _selectedTab, value);
        }
    }

    private readonly IServiceProvider _serviceProvider;
    private ImageConvertViewModel? _imageConvertV;
    private ImageWatermarkViewModel? _imageWatermarkV;
    private ImageScaleViewModel? _imageScaleV;
    private readonly ILocalizer _l;

    public IndexViewModel(IServiceProvider serviceProvider, ILocalizer l)
    {
        _serviceProvider = serviceProvider;
        _l = l;
        IsPaneOpen = true;
        SelectedTab = Tabs[0];
    }
}