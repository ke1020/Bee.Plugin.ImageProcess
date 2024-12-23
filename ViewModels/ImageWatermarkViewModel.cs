using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Ke.Bee.Localization.Localizer.Abstractions;
using Ke.ImageProcess.Models.Watermark;

namespace Bee.Plugin.ImageProcess.ViewModels;

public partial class ImageWatermarkViewModel : ImageProcessViewModelBase<ImageWatermarkArguments>
{
    /// <summary>
    /// 绑定到 ComboBox 的水印模式集合
    /// </summary>
    public IEnumerable<WatermarkMode> WatermarkModes => Enum.GetValues(typeof(WatermarkMode))
        .Cast<WatermarkMode>()
        .Where(e => (int)e > 0)
        ;
    /// <summary>
    /// 绑定到 ComboBox 的水印位置集合  
    /// </summary>
    public IEnumerable<WatermarkPosition> WatermarkPositions => Enum.GetValues(typeof(WatermarkPosition))
        .Cast<WatermarkPosition>()
        ;

    /// <summary>
    /// 当前是否图片水印模式
    /// </summary>
    [ObservableProperty]
    private bool _isWatermarkImageMode;

    public ImageWatermarkViewModel(TaskListViewModel<ImageWatermarkArguments> taskList, ILocalizer l) : base(taskList, l)
    {
        IsWatermarkImageMode = TaskList.TaskArguments?.WatermarkMode == WatermarkMode.Image;
    }

    public void OnWatermarkModeChanged(WatermarkMode watermarkMode)
    {
        IsWatermarkImageMode = watermarkMode == WatermarkMode.Image;
    }
}