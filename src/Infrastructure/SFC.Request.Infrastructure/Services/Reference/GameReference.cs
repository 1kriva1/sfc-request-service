using AutoMapper;

using SFC.Request.Application.Common.Dto.Game.General;
using SFC.Request.Application.Interfaces.Game.General;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Request.Application.Interfaces.Reference;

namespace SFC.Request.Infrastructure.Services.Reference;
public class GameReference(
    IMapper mapper,
    IGameRepository GameRepository,
    IGameService GameService) : BaseReference<GameEntity, long, GameDto>(mapper), IGameReference
{
    private readonly IGameRepository _gameRepository = GameRepository;
    private readonly IGameService _gameService = GameService;

    protected override Task<GameEntity?> GetFromLocalAsync(long id, CancellationToken cancellationToken = default)
        => _gameRepository.GetByIdAsync(id);

    protected override Task<GameDto?> GetFromReferenceAsync(long id, CancellationToken cancellationToken = default)
        => _gameService.GetGameAsync(id, cancellationToken);

    protected override Task<GameEntity> AddLocalAsync(GameEntity entity, CancellationToken cancellationToken = default)
        => _gameRepository.AddAsync(entity);
}