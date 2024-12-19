using Bee.Base.Abstractions.Navigation;
using Bee.Plugin.ImageProcess.ViewModels;

namespace Bee.Plugin.ImageProcess.Navigation.Commands;

public class ImageConvertNavigationCommand(IndexViewModel vm) : NavigationCommandBase<IndexViewModel>("ImageConvert", vm)
{
}
