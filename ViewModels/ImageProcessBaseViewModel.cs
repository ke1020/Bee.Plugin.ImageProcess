using System.Collections.ObjectModel;
using Bee.Base.Abstractions.Tasks;
using Bee.Base.Models;
using Bee.Base.Models.Tasks;
using Bee.Base.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bee.Plugin.ImageProcess.ViewModels;

public partial class ImageProcessBaseViewModel<T> : ObservableObject where T : TaskArgumentBase, new()
{
    /// <summary>
    /// 输出质量
    /// </summary>
    [ObservableProperty]
    private uint _quality = 90;
    /// <summary>
    /// 输出格式集合
    /// </summary>
    public List<string> OutputFormats => [.. ImageProcessConsts.AvailableImageFormats];
    /// <summary>
    /// 可选的输入图片格式集合
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<SelectableItem> _availableInputImageFormats = [.. ImageProcessConsts.AvailableImageFormats
        .Select(x => new SelectableItem { Label = x, IsSelected = true })]
        ;

    /// <summary>
    /// 任务列表控件视图模型
    /// </summary>
    public ITaskListViewModel<T> TaskList { get; }

    public ImageProcessBaseViewModel(TaskListViewModel<T> taskList)
    {
        TaskList = taskList;
        // 初始化任务参数
        TaskList.InitialArguments(ImageProcessConsts.PluginName);
        // 设置任务列表初始可选择的文件类型
        TaskList.SetInputExtensions(ImageProcessConsts.AvailableImageFormats);
    }

    /// <summary>
    /// 筛选文件类型改变事件
    /// </summary>
    [RelayCommand]
    private void InputExtensionsSelectChange()
    {
        TaskList.SetInputExtensions(AvailableInputImageFormats.Where(x => x.IsSelected == true).Select(x => x.Label));
    }
}