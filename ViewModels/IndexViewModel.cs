using Bee.Base.Models;
using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Views;

using Ke.Bee.Localization.Localizer.Abstractions;

namespace Bee.Plugin.ImageProcess.ViewModels;

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
