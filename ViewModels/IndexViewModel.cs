using Bee.Base.Models;
using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Views;

using Ke.Bee.Localization.Localizer.Abstractions;

namespace Bee.Plugin.ImageProcess.ViewModels;

/*
public partial class IndexViewModel : WorkspaceViewModel
{
    /// <summary>
    /// 任务列表控件视图模型
    /// </summary>
    public TaskListViewModel<ImageConvertArguments> TaskList { get; }

    public IndexViewModel(TaskListViewModel<ImageConvertArguments> taskList)
    {
        // 默认展开参数面板
        IsPaneOpen = true;
        // 将注入的视图模型赋值给 TaskList 属性
        TaskList = taskList;
        // 调用任务列表的 InitialArguments 方法
        TaskList.InitialArguments(ImageProcessConsts.PluginName);
        // 设置任务列表初始可选择的文件类型
        TaskList.SetInputExtensions(["jpg", "png", "bmp", "webp", "gif"]);
    }
}
*/






public partial class IndexViewModel : WorkspaceViewModel
{
    protected override List<TabMetadata> TabList => 
    [
        new ("Bee.Plugin.ImageProcess.Convert", typeof(ImageConvertView), typeof(ImageConvertViewModel)),
        new ("Bee.Plugin.ImageProcess.Scale", typeof(ImageScaleView), typeof(ImageScaleViewModel)),
        new ("Bee.Plugin.ImageProcess.Watermark", typeof(ImageWatermarkView), typeof(ImageWatermarkViewModel))
    ];


    public IndexViewModel(IServiceProvider serviceProvider, ILocalizer l) : base(serviceProvider, l)
    {
        IsPaneOpen = true;
    }
}