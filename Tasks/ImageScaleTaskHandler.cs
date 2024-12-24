

using Bee.Base.Abstractions.Tasks;
using Bee.Base.Models.Tasks;
using Bee.Plugin.ImageProcess.Models;
using Ke.ImageProcess.Abstractions;
using Ke.ImageProcess.Models.Scale;

namespace Bee.Plugin.ImageProcess.Tasks;

/// <summary>
/// 图片缩放任务处理器
/// </summary>
public class ImageScaleTaskHandler : ITaskHandler<ImageScaleArguments>
{
    private readonly IImageScaler _scaler;

    public ImageScaleTaskHandler(IImageScaler imageScaler)
    {
        _scaler = imageScaler;
    }

    public async Task<bool> ExecuteAsync(TaskItem taskItem, 
        ImageScaleArguments? args, 
        Action<double> progressCallback,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(args);
        
        _scaler.OnScaled += (sender, args) =>
        {
            progressCallback(100);
        };

        var request = new ImageScaleRequest([taskItem.FileName], args.OutputDirectory, args.OutputFormat)
        {
            ScaleMode = args.ScaleMode,
            Quality = args.Quality,
            Width = args.Width,
            Height = args.Height,
        };

        await _scaler.ScaleAsync(request);

        return true;
    }
}