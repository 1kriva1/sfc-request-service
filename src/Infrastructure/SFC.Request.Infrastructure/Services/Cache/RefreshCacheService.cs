using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Request.Data;
using SFC.Request.Application.Interfaces.Request.Data.Models;

namespace SFC.Request.Infrastructure.Services.Cache;
public class RefreshCacheService(ICache cache, IRequestDataService requestDataService) : IRefreshCache
{
    private readonly ICache _cache = cache;
    private readonly IRequestDataService _requestDataService = requestDataService;

    public async Task RefreshAsync(CancellationToken token = default)
    {
        GetAllRequestDataModel model = await _requestDataService.GetAllRequestDataAsync().ConfigureAwait(false);
        await RefreshAsync(model.RequestStatuses, token).ConfigureAwait(false);
    }

    private Task RefreshAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _cache.DeleteAsync($"{typeof(T).Name}", cancellationToken);
        return _cache.SetAsync($"{typeof(T).Name}", entities, null, cancellationToken);
    }
}