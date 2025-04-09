using SFC.Request.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Request.Domain.Entities.Team.Data;
using SFC.Request.Infrastructure.Persistence.Contexts;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Team.Data;
public class TeamPlayerStatusRepository(TeamDbContext context)
    : TeamDataRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(context), ITeamPlayerStatusRepository
{ }