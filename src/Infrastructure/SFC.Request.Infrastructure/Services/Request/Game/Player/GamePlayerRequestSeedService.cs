using AutoMapper;

using MassTransit;

using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;
using SFC.Request.Application.Interfaces.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Messages.Events.Request.Game.Player;

namespace SFC.Request.Infrastructure.Services.Request.Game.Player;
public class GamePlayerRequestSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    IGamePlayerRequestRepository gamePlayerRequestRepository,
    IGameRepository gameRepository) : IGamePlayerRequestSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository = gamePlayerRequestRepository;
    private readonly IGameRepository _gameRepository = gameRepository;

    #region Stub data

    private static readonly IEnumerable<(RequestStatusEnum, long)> Game_IDS =
    [
        (RequestStatusEnum.Accepted, 1),
        (RequestStatusEnum.Accepted, 2),
        (RequestStatusEnum.Accepted, 3),
        (RequestStatusEnum.Accepted, 4),
        (RequestStatusEnum.Accepted, 5),
        (RequestStatusEnum.Accepted, 6),
        (RequestStatusEnum.Accepted, 7),
        (RequestStatusEnum.Accepted, 8),
        (RequestStatusEnum.Canceled, 9),
        (RequestStatusEnum.Canceled, 10),
        (RequestStatusEnum.Canceled, 11),
        (RequestStatusEnum.Canceled, 12),
        (RequestStatusEnum.Declined, 13),
        (RequestStatusEnum.Declined, 14),
        (RequestStatusEnum.Declined, 15),
        (RequestStatusEnum.Declined, 16),
        (RequestStatusEnum.Actual, 17),
        (RequestStatusEnum.Actual, 18),
        (RequestStatusEnum.Actual, 19),
        (RequestStatusEnum.Actual, 20)
    ];
    private static readonly List<long> PLAYER_IDS = [20, 21, 22, 23, 24, 25];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<GamePlayerRequest>> GetSeedGamePlayerRequestsAsync()
    {
        return await _gamePlayerRequestRepository.GetByIdsAsync(Game_IDS.Select(item => item.Item2), PLAYER_IDS).ConfigureAwait(true);
    }

    public async Task SeedGamePlayerRequestsAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<GamePlayerRequest> Requests = await CreateSeedGamePlayerRequestsAsync().ConfigureAwait(true);

        GamePlayerRequest[] seedRequests = await _gamePlayerRequestRepository.AddRangeIfNotExistsAsync([.. Requests]).ConfigureAwait(true);

        await PublishGamePlayerRequestsSeededEventAsync(seedRequests, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Request, MetadataDomainEnum.GamePlayerRequest, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<GamePlayerRequest>> CreateSeedGamePlayerRequestsAsync()
    {
        List<GamePlayerRequest> result = [];

        foreach ((RequestStatusEnum, long) item in Game_IDS)
        {
            IEnumerable<GamePlayerRequest> part = await BuildGamePlayerRequestAsync(item.Item2, item.Item1).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<GamePlayerRequest>> BuildGamePlayerRequestAsync(long gameId, RequestStatusEnum status)
    {
        GameEntity? game = await _gameRepository.GetByIdAsync(gameId).ConfigureAwait(true);

        Guid userId = game!.UserId;

        DateTime createdDate = _dateTimeService.Now;

        return PLAYER_IDS.Select(playerId => new GamePlayerRequest()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
            UserId = userId,
            GameId = gameId,
            PlayerId = playerId,
            StatusId = status,
            GameComment = status == RequestStatusEnum.Declined ? "Seed player comment" : null,
            PlayerComment = "Seed Request"
        });
    }

    private Task PublishGamePlayerRequestsSeededEventAsync(IEnumerable<GamePlayerRequest> Games, CancellationToken cancellationToken = default)
    {
        GamePlayerRequestsSeeded @event = _mapper.Map<GamePlayerRequestsSeeded>(Games);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}