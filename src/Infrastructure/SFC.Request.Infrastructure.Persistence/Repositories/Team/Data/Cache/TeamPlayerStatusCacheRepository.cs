using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Request.Domain.Entities.Team.Data;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamPlayerStatusCacheRepository(TeamPlayerStatusRepository repository, [FromKeyedServices(CacheInstance.Team)] ICache cache)
    : TeamDataCacheRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(repository, cache), ITeamPlayerStatusRepository
{ }