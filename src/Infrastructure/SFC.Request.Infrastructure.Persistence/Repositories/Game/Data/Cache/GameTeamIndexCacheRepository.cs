using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Game.Data.Cache;
public class GameTeamIndexCacheRepository(GameTeamIndexRepository repository, [FromKeyedServices(CacheInstance.Game)] ICache cache)
    : GameDataCacheRepository<GameTeamIndex, GameTeamIndexEnum>(repository, cache), IGameTeamIndexRepository
{ }