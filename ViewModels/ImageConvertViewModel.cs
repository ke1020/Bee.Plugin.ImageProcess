using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Models;

namespace Bee.Plugin.ImageProcess.ViewModels;

public partial class ImageConvertViewModel : ImageProcessBaseViewModel<ImageConvertArguments>
{
    public ImageConvertViewModel(TaskListViewModel<ImageConvertArguments> taskList) : base(taskList)
    {

    }
}