using Bee.Base.Abstractions;
using Bee.Base.Abstractions.Tasks;
using Bee.Base.Models.Tasks;
using Bee.Plugin.ImageProcess.Models;

using Ke.ImageProcess.Abstractions;
using Ke.ImageProcess.Models.Scale;

using LanguageExt;

namespace Bee.Plugin.ImageProcess.Tasks;

/// <summary>
/// 图片缩放任务处理器
/// </summary>
public class ImageScaleTaskHandler(IImageScaler imageScaler, ICoverHandler coverHandler) :
    TaskHandlerBase<ImageScaleArguments>(coverHandler)
{
    private readonly IImageScaler _scaler = imageScaler;

    public override async Task<Fin<Unit>> ExecuteAsync(TaskItem taskItem,
        ImageScaleArguments args,
        Action<double> progressCallback,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _scaler.OnScaled += (sender, args) => progressCallback(100);

        var request = new ImageScaleRequest([taskItem.Input], args.OutputDirectory, args.OutputFormat)
        {
            ScaleMode = args.ScaleMode,
            Quality = args.Quality,
            Width = args.Width,
            Height = args.Height,
        };

        await _scaler.ScaleAsync(request);

        return Fin<Unit>.Succ(Unit.Default);
    }
}