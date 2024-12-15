
using Bee.Base.Models.Tasks;

namespace Bee.Plugin.ImageProcess.Models;

/// <summary>
/// 图片处理参数基类
/// </summary>
public class ImageProcessArgumentBase : TaskArgumentBase
{
    public string OutputFormat { get; set; } = ImageProcessConsts.DefaultOutputFormat;
    public uint Quality { get; set; } = 90;
}