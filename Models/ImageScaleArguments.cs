using Bee.Base.Models.Tasks;
using Ke.ImageProcess.Models.Scale;

namespace Bee.Plugin.ImageProcess.Models;

/// <summary>
/// 图片缩放参数
/// </summary>
public class ImageScaleArguments : ImageProcessArgumentBase
{
    public ScaleMode ScaleMode { get; set; } = ScaleMode.EqualRatio;
    public uint? Width { get; set; }
    public uint? Height { get; set; }
}