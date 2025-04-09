using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Data;
using SFC.Request.Domain.Entities.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Data.Cache;
public class ShirtCacheRepository(ShirtRepository repository, ICache cache)
    : DataCacheRepository<Shirt, ShirtEnum>(repository, cache), IShirtRepository
{ }