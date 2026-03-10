using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Data;
using SFC.Request.Domain.Entities.Data;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Data.Cache;
public class FootballPositionCacheRepository(FootballPositionRepository repository, [FromKeyedServices(CacheInstance.Data)] ICache cache)
    : DataCacheRepository<FootballPosition, FootballPositionEnum>(repository, cache), IFootballPositionRepository
{ }