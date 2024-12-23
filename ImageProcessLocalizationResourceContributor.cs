using Bee.Base.Abstractions.Localization;
using Bee.Base.Models;
using Microsoft.Extensions.Options;

namespace Bee.Plugin.ImageProcess;

public class ImageProcessLocalizationResourceContributor(IOptions<AppSettings> appSettings) :
        LocalizationResourceContributorBase(appSettings, ImageProcessConsts.PluginName)
{
}