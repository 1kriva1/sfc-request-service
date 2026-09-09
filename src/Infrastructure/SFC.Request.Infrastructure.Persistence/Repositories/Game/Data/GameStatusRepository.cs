using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Infrastructure.Persistence.Contexts;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Game.Data;
public class GameStatusRepository(GameDbContext context)
    : GameDataRepository<GameStatus, GameStatusEnum>(context), IGameStatusRepository
{ }