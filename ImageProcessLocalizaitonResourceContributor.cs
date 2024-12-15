using Bee.Base.Abstractions.Localization;
using Bee.Base.Models;
using Bee.Plugin.ImageProcess;
using Microsoft.Extensions.Options;

public class ImageProcessLocalizationResourceContributor(IOptions<AppSettings> appSettings) : 
    LocalizationResourceContributorBase(appSettings, ImageProcessConsts.PluginName)
{
}