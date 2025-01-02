
using Bee.Base.Abstractions;
using Bee.Base.Abstractions.Tasks;
using Bee.Base.Models.Tasks;
using Bee.Plugin.ImageProcess.Models;

using Ke.ImageProcess.Abstractions;
using Ke.ImageProcess.Models.Convert;

using LanguageExt;

namespace Bee.Plugin.ImageProcess.Tasks;

/// <summary>
/// 图片转换任务处理器
/// </summary>
public class ImageConvertTaskHandler(IImageConverter imageConverter, ICoverHandler coverHandler) :
    TaskHandlerBase<ImageConvertArguments>(coverHandler)
{
    private readonly IImageConverter _imageConverter = imageConverter;

    public override async Task<Fin<Unit>> ExecuteAsync(TaskItem taskItem,
        ImageConvertArguments argments,
        Action<double> progressCallback,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // 监听转换完成事件
        _imageConverter.OnConverted += (sender, e) => progressCallback(100);

        var req = new ImageConvertRequest([taskItem.Input], argments.OutputDirectory, argments.OutputFormat)
        {
            Quality = argments.Quality
        };

        // 执行转换
        await _imageConverter.ConvertAsync(req, cancellationToken);

        return Fin<Unit>.Succ(Unit.Default);
    }
}