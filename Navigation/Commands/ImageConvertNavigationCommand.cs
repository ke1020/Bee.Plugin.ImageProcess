using Bee.Base.Abstractions.Navigation;
using Bee.Plugin.ImageProcess.ViewModels;

public class ImageConvertNavigationCommand(IndexViewModel vm) : NavigationCommandBase<IndexViewModel>("ImageConvert", vm)
{
}