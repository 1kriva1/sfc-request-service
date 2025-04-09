using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Request.Domain.Entities.Team.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamPlayerStatusCacheRepository(TeamPlayerStatusRepository repository, ICache cache)
    : TeamDataCacheRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(repository, cache), ITeamPlayerStatusRepository
{ }