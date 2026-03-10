using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Data;
using SFC.Request.Domain.Entities.Data;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Data.Cache;
public class ShirtCacheRepository(ShirtRepository repository, [FromKeyedServices(CacheInstance.Data)] ICache cache)
    : DataCacheRepository<Shirt, ShirtEnum>(repository, cache), IShirtRepository
{ }