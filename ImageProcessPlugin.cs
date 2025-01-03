using Bee.Base.Abstractions.Navigation;
using Bee.Base.Abstractions.Plugin;
using Bee.Base.Abstractions.Tasks;
using Bee.Base.ViewModels;
using Bee.Plugin.ImageProcess.Models;
using Bee.Plugin.ImageProcess.Navigation.Commands;
using Bee.Plugin.ImageProcess.Tasks;
using Bee.Plugin.ImageProcess.ViewModels;
using Bee.Plugin.ImageProcess.Views;
using Ke.Bee.Localization.Providers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Bee.Plugin.ImageProcess;

public class ImageProcessPlugin(IServiceProvider serviceProvider) : PluginBase(serviceProvider)
{
    public override string PluginName => ImageProcessConsts.PluginName;

    // public override string InjectMenuKey => "AI";

    public override void RegisterServices(IServiceCollection services)
    {
        // 本地化与导航命令
        services.AddTransient<IPlugin, ImageProcessPlugin>();
        services.AddSingleton<ILocalizationResourceContributor, ImageProcessLocalizationResourceContributor>();
        services.AddSingleton<INavigationCommand, ImageConvertNavigationCommand>();

        // 注入视图
        services.AddTransient<ImageConvertView>();
        services.AddTransient<ImageScaleView>();
        services.AddTransient<ImageWatermarkView>();

        // 注入视图模型
        services.AddTransient<IndexViewModel>();
        services.AddTransient<ImageWatermarkViewModel>();
        services.AddTransient<ImageConvertViewModel>();
        services.AddTransient<ImageScaleViewModel>();

        // 注入任务列表控件视图
        services.AddTransient<TaskListViewModel<ImageConvertArguments>>();
        services.AddTransient<TaskListViewModel<ImageWatermarkArguments>>();
        services.AddTransient<TaskListViewModel<ImageScaleArguments>>();

        // 注入图片处理相关服务
        services.AddImageSharp();

        // 注入任务处理相关服务
        services.AddTransient<ITaskHandler<ImageWatermarkArguments>, ImageWatermarkTaskHandler>();
        services.AddTransient<ITaskHandler<ImageConvertArguments>, ImageConvertTaskHandler>();
        services.AddTransient<ITaskHandler<ImageScaleArguments>, ImageScaleTaskHandler>();
    }
}
