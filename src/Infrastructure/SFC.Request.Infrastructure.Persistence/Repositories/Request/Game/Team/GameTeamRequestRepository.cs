using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Domain.Common.Interfaces;
using SFC.Request.Domain.Entities.Request.Game.Team;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Extensions;
using SFC.Request.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Request.Game.Team;
public class GameTeamRequestRepository(RequestDbContext context)
    : Repository<GameTeamRequest, RequestDbContext, long>(context), IGameTeamRequestRepository
{
    #region Public

    public override Task<GameTeamRequest?> GetByIdAsync(long id)
    {
        return Context.GameTeamRequests
                     .ThanIncludeTeam()
                     .ThanIncludeGame()
                     .FirstOrDefaultAsync(Request => Request.Id == id);
    }

    public Task<GameTeamRequest?> GetByIdAsync(long id, long gameId, long teamId)
    {
        return Context.GameTeamRequests
                      .ThanIncludeTeam()
                      .ThanIncludeGame()
                      .FirstOrDefaultAsync(Request => Request.Id == id && Request.GameId == gameId && Request.Team.Id == teamId);
    }

    public async Task<IEnumerable<GameTeamRequest>> GetByIdsAsync(IEnumerable<long> ids)
    {
        return await Context.GameTeamRequests
                            .ThanIncludeTeam()
                            .ThanIncludeGame()
                            .Where(Request => ids.Contains(Request.Id))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IEnumerable<GameTeamRequest>> GetByIdsAsync(IEnumerable<long> gameIds, IEnumerable<long> teamIds)
    {
        return await Context.GameTeamRequests
                            .Where(Request => gameIds.Contains(Request.GameId) && teamIds.Contains(Request.TeamId))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IReadOnlyList<GameTeamRequest>> ListAllAsync(long gameId)
    {
        return await Context.GameTeamRequests
                            .ThanIncludeTeam()
                            .ThanIncludeGame()
                            .Where(gameTeam => gameTeam.GameId == gameId)
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.GameTeamRequests.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.GameTeamRequests.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public Task<bool> AnyAsync(long gameId, long teamId, RequestStatusEnum? status)
    {
        return status.HasValue
            ? Context.GameTeamRequests.AnyAsync(Request => Request.GameId == gameId && Request.StatusId == status && Request.Team.Id == teamId)
            : Context.GameTeamRequests.AnyAsync(Request => Request.GameId == gameId && Request.Team.Id == teamId);
    }

    public async Task<GameTeamRequest[]> AddRangeIfNotExistsAsync(params GameTeamRequest[] entities)
    {
        await Context.Set<GameTeamRequest>().AddRangeIfNotExistsAsync<GameTeamRequest, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    public override Task<PagedList<GameTeamRequest>> FindAsync(FindParameters<GameTeamRequest> parameters)
    {
        return Context.GameTeamRequests
                      .ThanIncludeTeam()
                      .ThanIncludeGame()
                      .AsQueryable<GameTeamRequest>()
                      .PaginateAsync(parameters);
    }

    #endregion Ovveride
}