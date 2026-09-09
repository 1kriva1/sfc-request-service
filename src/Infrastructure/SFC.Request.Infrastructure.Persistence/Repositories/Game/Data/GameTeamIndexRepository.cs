using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Infrastructure.Persistence.Contexts;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Game.Data;
public class GameTeamIndexRepository(GameDbContext context)
    : GameDataRepository<GameTeamIndex, GameTeamIndexEnum>(context), IGameTeamIndexRepository
{ }