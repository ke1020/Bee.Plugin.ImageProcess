
using Ke.ImageProcess.Models.Watermark;

namespace Bee.Plugin.ImageProcess.Models;

/// <summary>
/// 水印参数
/// </summary>
public class ImageWatermarkArguments : ImageProcessArgumentBase
{
    /// <summary>
    /// 水印模式
    /// </summary>
    public WatermarkMode WatermarkMode { get; set; } = WatermarkMode.Image;
    /// <summary>
    /// 水印位置
    /// </summary>
    public WatermarkPosition WatermarkPosition { get; set; } = WatermarkPosition.BottomRight;
    /// <summary>
    /// 水印图片，水印模式为图片类型时有效
    /// </summary>
    public string? WatermarkImage { get; set; }
    /// <summary>
    /// 水印文本，水印模式为文本类型时有效
    /// </summary>
    public string? WatermarkText { get; set; } = "仅供办理 xx 业务使用";
    /// <summary>
    /// 字体大小，水印模式为文本类型时有效
    /// </summary>
    public byte FontSize { get; set; } = 25;
    /// <summary>
    /// 是否平铺
    /// </summary>
    public bool IsTile { get; set; } = false;
    /// <summary>
    /// 0 - 100 之间
    /// </summary>
    public byte Opacity { get; set; } = 100;
    /// <summary>
    /// 水印旋转角度
    /// </summary>
    public ushort Rotation { get; set; } = 45;
}