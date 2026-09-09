using AutoMapper;

using MassTransit;

using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Application.Interfaces.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;
using SFC.Request.Messages.Events.Request.Game.Team;

namespace SFC.Request.Infrastructure.Services.Request.Game.Team;
public class GameTeamRequestSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    IGameTeamRequestRepository gameTeamRequestRepository,
    IGameRepository gameRepository) : IGameTeamRequestSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository = gameTeamRequestRepository;
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
    private static readonly List<long> Team_IDS = [20, 21, 22, 23, 24, 25];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<GameTeamRequest>> GetSeedGameTeamRequestsAsync()
    {
        return await _gameTeamRequestRepository.GetByIdsAsync(Game_IDS.Select(item => item.Item2), Team_IDS).ConfigureAwait(true);
    }

    public async Task SeedGameTeamRequestsAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<GameTeamRequest> Requests = await CreateSeedGameTeamRequestsAsync().ConfigureAwait(true);

        GameTeamRequest[] seedRequests = await _gameTeamRequestRepository.AddRangeIfNotExistsAsync([.. Requests]).ConfigureAwait(true);

        await PublishGameTeamRequestsSeededEventAsync(seedRequests, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Request, MetadataDomainEnum.GameTeamRequest, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<GameTeamRequest>> CreateSeedGameTeamRequestsAsync()
    {
        List<GameTeamRequest> result = [];

        foreach ((RequestStatusEnum, long) item in Game_IDS)
        {
            IEnumerable<GameTeamRequest> part = await BuildGameTeamRequestAsync(item.Item2, item.Item1).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<GameTeamRequest>> BuildGameTeamRequestAsync(long gameId, RequestStatusEnum status)
    {
        GameEntity? game = await _gameRepository.GetByIdAsync(gameId).ConfigureAwait(true);

        Guid userId = game!.UserId;

        DateTime createdDate = _dateTimeService.Now;

        return Team_IDS.Select(teamId => new GameTeamRequest()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
            UserId = userId,
            GameId = gameId,
            TeamId = teamId,
            StatusId = status,
            GameComment = status == RequestStatusEnum.Declined ? "Seed Team comment" : null,
            TeamComment = "Seed Request"
        });
    }

    private Task PublishGameTeamRequestsSeededEventAsync(IEnumerable<GameTeamRequest> Games, CancellationToken cancellationToken = default)
    {
        GameTeamRequestsSeeded @event = _mapper.Map<GameTeamRequestsSeeded>(Games);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}