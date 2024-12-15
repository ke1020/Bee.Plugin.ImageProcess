
using Bee.Base.Abstractions.Tasks;
using Ke.ImageProcess.Abstractions;

namespace Bee.Plugin.ImageProcess.Tasks;

/// <summary>
/// 图片封面处理器
/// </summary>
public class TaskCoverHandler : ITaskCoverHandler
{
    private readonly IImageScaler _scaler;

    public TaskCoverHandler(IImageScaler scaler)
    {
        _scaler = scaler;
    }

    public async Task<Stream?> GetCoverAsync(string imageSource)
    {
        // 返回缩放后的图片流
        return await _scaler.GetScaleStreamAsync(imageSource, 80, 80);
    }
}