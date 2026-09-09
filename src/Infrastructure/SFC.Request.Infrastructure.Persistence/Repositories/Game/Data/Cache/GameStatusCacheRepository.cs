using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Game.Data.Cache;
public class GameStatusCacheRepository(GameStatusRepository repository, [FromKeyedServices(CacheInstance.Game)] ICache cache)
    : GameDataCacheRepository<GameStatus, GameStatusEnum>(repository, cache), IGameStatusRepository
{ }