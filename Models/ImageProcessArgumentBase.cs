
using Bee.Base.Models.Tasks;

namespace Bee.Plugin.ImageProcess.Models;

/// <summary>
/// 图片处理参数基类
/// </summary>
public class ImageProcessArgumentBase : TaskArgumentBase
{
    /// <summary>
    /// 输出图片格式
    /// </summary>
    public string OutputFormat { get; set; } = ImageProcessConsts.DefaultOutputFormat;
    /// <summary>
    /// 输出质量
    /// </summary>
    public uint Quality { get; set; } = 90;
}