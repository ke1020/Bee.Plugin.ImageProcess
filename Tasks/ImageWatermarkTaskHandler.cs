using Bee.Base.Abstractions;
using Bee.Base.Abstractions.Tasks;
using Bee.Base.Models.Tasks;
using Bee.Plugin.ImageProcess.Models;

using Ke.ImageProcess.Abstractions;
using Ke.ImageProcess.Models;
using Ke.ImageProcess.Models.Watermark;

using LanguageExt;

namespace Bee.Plugin.ImageProcess.Tasks;

/// <summary>
/// 图片水印任务处理器
/// </summary>
public class ImageWatermarkTaskHandler(IImageWatermarker imageWatermarker, ICoverHandler coverHandler) :
    TaskHandlerBase<ImageWatermarkArguments>(coverHandler)
{
    private readonly IImageWatermarker _imageWatermarker = imageWatermarker;

    private readonly Dictionary<WatermarkMode, Func<ImageWatermarkArguments, WatermarkBase>> _watermarkModes = new()
    {
        {
            // 图片水印
            WatermarkMode.Image, (args) =>
            {
                if (args.WatermarkImage == null || !File.Exists(args.WatermarkImage))
                {
                    throw new WatermarkImageNotExistsException();
                }

                return new ImageWatermark(args.WatermarkImage);
            }
        },
        {
            // 文本水印
            WatermarkMode.Text, (args) =>
            {
                return new TextWatermark(args.WatermarkText ?? string.Empty)
                {
                    // ImageSharp 可以写安装到系统的字体名称（与 ImageMagick 不同）
                    // FontFamily = "HarmonyOS Sans SC",
                    FontFamily = "Microsoft YaHei",
                    FontSize = args.FontSize,
                    TextColor = new RgbaColor(200, 200, 200, 50),
                    //StrokeColor = new RgbaColor(255, 255, 255, 50),
                    StrokeWidth = 2,
                    // BackgroundColor = new RgbaColor(0, 0, 0, 0),
                };
            }
        }
    };

    public override async Task<Fin<Unit>> ExecuteAsync(TaskItem taskItem,
        ImageWatermarkArguments? argments,
        Action<double> progressCallback,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(argments);

        if (!_watermarkModes.TryGetValue(argments.WatermarkMode, out var callWatermark))
        {
            return Fin<Unit>.Fail(new UnknowWatermarkModeException());
        }

        var w = callWatermark(argments);

        _imageWatermarker.OnWatermarked += (sender, e) => progressCallback(100);

        var options = new ImageWatermarkRequest<WatermarkBase>(
            [taskItem.Input],
            argments.OutputDirectory,
            argments.OutputFormat)
        {
            Mode = argments.WatermarkMode,
            Watermark = w,
            // IsTite 为 true 时该项无效
            Position = argments.WatermarkPosition,
            Opacity = (double)argments.Opacity / 100,
            Suffix = "-wt",
            Rotation = argments.Rotation,
            IsTile = argments.IsTile
        };

        await _imageWatermarker.WatermarkAsync(options);

        return Fin<Unit>.Succ(Unit.Default);
    }


    /*
    // Avalonia 原生 API 绘制文本图片
    //using(var asset = AssetLoader.Open(new Uri()))
    {
        var typeface = new Typeface(FontFamily.Default);
        // 设置文本格式
        var formattedText = new FormattedText(args.WatermarkText ?? string.Empty,
            CultureInfo.CurrentUICulture,
            FlowDirection.LeftToRight,
            typeface,
            36, // 字体大小
            Brushes.Black) // 文字颜色
            ;

        // 计算文本尺寸并添加边距
        double margin = 20; // 边距
        double width = formattedText.Width + 2 * margin;
        double height = formattedText.Height + 2 * margin;
        // 创建位图
        using var render = new RenderTargetBitmap(new Avalonia.PixelSize((int)width, (int)height));
        // 创建一个绘图上下文
        using var drawingContext = render.CreateDrawingContext();
        // 清除背景
        drawingContext.DrawText(formattedText, new Avalonia.Point(margin, margin));

        render.Save(strema);
    }
    */
}