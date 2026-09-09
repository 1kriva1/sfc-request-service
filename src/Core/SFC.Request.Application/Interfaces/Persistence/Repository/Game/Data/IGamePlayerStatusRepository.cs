using SFC.Request.Domain.Entities.Game.Data;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Game.Data;
public interface IGamePlayerStatusRepository : IGameDataRepository<GamePlayerStatus, GamePlayerStatusEnum> { }