using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Models;
using Ke.ImageProcess.Models.Scale;

namespace Bee.Plugin.ImageProcess.ViewModels;

public partial class ImageScaleViewModel : ImageProcessBaseViewModel<ImageScaleArguments>
{
    public IEnumerable<ScaleMode> ScaleModes => Enum.GetValues(typeof(ScaleMode))
        .Cast<ScaleMode>()
        .Where(e => (int)e > 0)
        ;
        
    public ImageScaleViewModel(TaskListViewModel<ImageScaleArguments> taskList) : base(taskList)
    {

    }
}