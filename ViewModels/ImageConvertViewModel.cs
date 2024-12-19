using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Models;
using Ke.Bee.Localization.Localizer.Abstractions;

namespace Bee.Plugin.ImageProcess.ViewModels;

public partial class ImageConvertViewModel(TaskListViewModel<ImageConvertArguments> taskList, ILocalizer l) 
    : ImageProcessBaseViewModel<ImageConvertArguments>(taskList, l)
{
}