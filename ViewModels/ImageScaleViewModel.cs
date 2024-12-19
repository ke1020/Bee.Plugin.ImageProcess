using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Models;
using Ke.Bee.Localization.Localizer.Abstractions;
using Ke.ImageProcess.Models.Scale;

namespace Bee.Plugin.ImageProcess.ViewModels;

public partial class ImageScaleViewModel(TaskListViewModel<ImageScaleArguments> taskList, ILocalizer l) 
    : ImageProcessBaseViewModel<ImageScaleArguments>(taskList, l)
{
    public IEnumerable<ScaleMode> ScaleModes => Enum.GetValues(typeof(ScaleMode))
        .Cast<ScaleMode>()
        .Where(e => (int)e > 0)
        ;
}