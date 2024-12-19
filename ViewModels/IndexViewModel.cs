using Avalonia.Controls;
using Bee.Base.Models;
using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Views;
using Ke.Bee.Localization.Localizer.Abstractions;

namespace Bee.Plugin.ImageProcess.ViewModels;

public partial class IndexViewModel : WorkspaceViewModel
{
    private readonly List<TabMetadata> _tabs =
    [
        new ("Bee.Plugin.ImageProcess.Convert", typeof(ImageConvertView), typeof(ImageConvertViewModel)),
        new ("Bee.Plugin.ImageProcess.Scale", typeof(ImageScaleView), typeof(ImageScaleViewModel)),
        new ("Bee.Plugin.ImageProcess.Watermark", typeof(ImageWatermarkView), typeof(ImageWatermarkViewModel))
    ];

    /// <summary>
    /// 标签页
    /// </summary>
    public List<TabItem> Tabs => _tabs.Select((x, i) => new TabItem { TabIndex = i, Header = _l[x.LocalKey] }).ToList();

    private int _selectedTabIndex = 0;

    private TabItem? _selectedTab;
    /// <summary>
    /// 选中项
    /// </summary>
    public TabItem SelectedTab
    {
        get => _selectedTab ?? Tabs[_selectedTabIndex];
        set
        {
            InitialTab(value, _tabs[value.TabIndex]);
            SetProperty(ref _selectedTab, value);
        }
    }

    private readonly IServiceProvider _serviceProvider;
    private readonly ILocalizer _l;

    public IndexViewModel(IServiceProvider serviceProvider, ILocalizer l)
    {
        _serviceProvider = serviceProvider;
        _l = l;
        IsPaneOpen = true;
    }

    /// <summary>
    /// 初始化标签页
    /// </summary>
    /// <param name="tabItem">标签对象</param>
    /// <param name="tabMetadata">标签元数据信息</param>
    private void InitialTab(TabItem tabItem, TabMetadata tabMetadata)
    {
        var view = _serviceProvider.GetService(tabMetadata.ViewType) as UserControl;
        var vm = _serviceProvider.GetService(tabMetadata.ViewModelType);
        tabItem.DataContext = vm;
        view!.DataContext = vm;
        tabItem.Content = view;
    }
}