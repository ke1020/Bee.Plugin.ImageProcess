using Bee.Base.Abstractions.Plugin;
using Microsoft.Extensions.DependencyInjection;

namespace Bee.Plugin.ImageProcess;

public class ImageProcessPlugin : PluginBase
{
    public ImageProcessPlugin(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override string PluginName => ImageProcessConsts.PluginName;

    // public override string InjectMenuKey => "AI";

    public override void RegisterServices(IServiceCollection services)
    {
        
    }
}
