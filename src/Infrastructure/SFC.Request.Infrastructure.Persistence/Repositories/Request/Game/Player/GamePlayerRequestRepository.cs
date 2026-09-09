using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;
using SFC.Request.Domain.Common.Interfaces;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Extensions;
using SFC.Request.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Request.Game.Player;
public class GamePlayerRequestRepository(RequestDbContext context)
    : Repository<GamePlayerRequest, RequestDbContext, long>(context), IGamePlayerRequestRepository
{
    #region Public

    public override Task<GamePlayerRequest?> GetByIdAsync(long id)
    {
        return Context.GamePlayerRequests
                     .ThanIncludePlayer()
                     .ThanIncludeGame()
                     .FirstOrDefaultAsync(Request => Request.Id == id);
    }

    public Task<GamePlayerRequest?> GetByIdAsync(long id, long gameId, long playerId)
    {
        return Context.GamePlayerRequests
                      .ThanIncludePlayer()
                      .ThanIncludeGame()
                      .FirstOrDefaultAsync(Request => Request.Id == id && Request.GameId == gameId && Request.Player.Id == playerId);
    }

    public async Task<IEnumerable<GamePlayerRequest>> GetByIdsAsync(IEnumerable<long> ids)
    {
        return await Context.GamePlayerRequests
                            .ThanIncludePlayer()
                            .ThanIncludeGame()
                            .Where(Request => ids.Contains(Request.Id))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IEnumerable<GamePlayerRequest>> GetByIdsAsync(IEnumerable<long> gameIds, IEnumerable<long> playerIds)
    {
        return await Context.GamePlayerRequests
                            .Where(Request => gameIds.Contains(Request.GameId) && playerIds.Contains(Request.PlayerId))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IReadOnlyList<GamePlayerRequest>> ListAllAsync(long gameId)
    {
        return await Context.GamePlayerRequests
                            .ThanIncludePlayer()
                            .ThanIncludeGame()
                            .Where(gamePlayer => gamePlayer.GameId == gameId)
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.GamePlayerRequests.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.GamePlayerRequests.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public Task<bool> AnyAsync(long gameId, long playerId, RequestStatusEnum? status)
    {
        return status.HasValue
            ? Context.GamePlayerRequests.AnyAsync(Request => Request.GameId == gameId && Request.StatusId == status && Request.Player.Id == playerId)
            : Context.GamePlayerRequests.AnyAsync(Request => Request.GameId == gameId && Request.Player.Id == playerId);
    }

    public async Task<GamePlayerRequest[]> AddRangeIfNotExistsAsync(params GamePlayerRequest[] entities)
    {
        await Context.Set<GamePlayerRequest>().AddRangeIfNotExistsAsync<GamePlayerRequest, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    public override Task<PagedList<GamePlayerRequest>> FindAsync(FindParameters<GamePlayerRequest> parameters)
    {
        return Context.GamePlayerRequests
                      .ThanIncludePlayer()
                      .ThanIncludeGame()
                      .AsQueryable<GamePlayerRequest>()
                      .PaginateAsync(parameters);
    }

    #endregion Ovveride
}