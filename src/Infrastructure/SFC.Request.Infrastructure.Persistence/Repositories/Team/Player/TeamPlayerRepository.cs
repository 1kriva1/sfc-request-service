using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Request.Domain.Entities.Team.Player;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Extensions;
using SFC.Request.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Team.Player;
public class TeamPlayerRepository(TeamDbContext context)
    : Repository<TeamPlayer, TeamDbContext, long>(context), ITeamPlayerRepository
{
    public override Task<PagedList<TeamPlayer>> FindAsync(FindParameters<TeamPlayer> parameters)
    {
        return Context.TeamPlayers
                      .ThanIncludePlayer()
                      .AsQueryable()
                      .PaginateAsync(parameters);
    }

    public Task<TeamPlayer?> GetByIdAsync(long teamId, long playerId)
    {
        return Context.TeamPlayers.FirstOrDefaultAsync(item => item.TeamId == teamId && item.Player.Id == playerId);
    }

    public Task<bool> AnyAsync(long teamId, long playerId)
    {
        return Context.TeamPlayers.AnyAsync(item => item.TeamId == teamId && item.Player.Id == playerId);
    }

    public Task<bool> AnyAsync(long teamId, long playerId, TeamPlayerStatusEnum status)
    {
        return Context.TeamPlayers.AnyAsync(teamPlayer =>
            teamPlayer.TeamId == teamId &&
            teamPlayer.StatusId == status &&
            teamPlayer.Player.Id == playerId);
    }

    public async Task<TeamPlayer[]> AddRangeIfNotExistsAsync(params TeamPlayer[] entities)
    {
        await Context.Set<TeamPlayer>().AddRangeIfNotExistsAsync<TeamPlayer, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }
}