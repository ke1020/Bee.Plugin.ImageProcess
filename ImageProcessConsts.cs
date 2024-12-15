namespace Bee.Plugin.ImageProcess;

public class ImageProcessConsts
{
    public const string PluginName = "ImageProcess";
    /// <summary>
    /// 可用的图片格式（支持处理的图片格式）
    /// </summary>
    public static string[] AvailableImageFormats => ["jpg", "png", "bmp", "webp", "gif"];

    public const string DefaultOutputFormat = "jpg";
}