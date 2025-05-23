using AutoMapper;

using MassTransit;

using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Request.Application.Interfaces.Request.Team.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;
using SFC.Request.Messages.Events.Request.Team.Player;

namespace SFC.Request.Infrastructure.Services.Request.Team.Player;
public class TeamPlayerRequestSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    ITeamPlayerRequestRepository teamPlayerRequestRepository,
    ITeamRepository teamRepository) : ITeamPlayerRequestSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly ITeamPlayerRequestRepository _teamPlayerRequestRepository = teamPlayerRequestRepository;
    private readonly ITeamRepository _teamRepository = teamRepository;

    #region Stub data

    private static readonly IEnumerable<(RequestStatusEnum, long)> TEAM_IDS =
    [
        (RequestStatusEnum.Actual, 17),
        (RequestStatusEnum.Actual, 18),
        (RequestStatusEnum.Actual, 19),
        (RequestStatusEnum.Actual, 20),
        (RequestStatusEnum.Accepted, 21),
        (RequestStatusEnum.Accepted, 22),
        (RequestStatusEnum.Accepted, 23),
        (RequestStatusEnum.Accepted, 24),
        (RequestStatusEnum.Canceled, 25),
        (RequestStatusEnum.Canceled, 26),
        (RequestStatusEnum.Canceled, 27),
        (RequestStatusEnum.Canceled, 28),
        (RequestStatusEnum.Declined, 29),
        (RequestStatusEnum.Declined, 30),
        (RequestStatusEnum.Declined, 31),
        (RequestStatusEnum.Declined, 32)
    ];
    private static readonly List<long> PLAYER_IDS = [26, 27, 28, 29, 30, 31];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<TeamPlayerRequest>> GetSeedTeamPlayerRequestsAsync()
    {
        return await _teamPlayerRequestRepository
            .GetByIdsAsync(TEAM_IDS.Select(item => item.Item2), PLAYER_IDS)
            .ConfigureAwait(true);
    }

    public async Task SeedTeamPlayerRequestsAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<TeamPlayerRequest> requests = await CreateSeedTeamPlayerRequestsAsync().ConfigureAwait(true);

        TeamPlayerRequest[] seedRequests = await
            _teamPlayerRequestRepository.AddRangeIfNotExistsAsync([.. requests]).ConfigureAwait(true);

        await PublishTeamPlayerRequestsSeededEventAsync(seedRequests, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Request, MetadataDomainEnum.TeamPlayerRequest, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<TeamPlayerRequest>> CreateSeedTeamPlayerRequestsAsync()
    {
        List<TeamPlayerRequest> result = [];

        foreach ((RequestStatusEnum, long) item in TEAM_IDS)
        {
            IEnumerable<TeamPlayerRequest> part = await BuildTeamPlayerRequestAsync(item.Item2, item.Item1).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<TeamPlayerRequest>> BuildTeamPlayerRequestAsync(long teamId, RequestStatusEnum status)
    {
        TeamEntity? team = await _teamRepository.GetByIdAsync(teamId).ConfigureAwait(true);

        Guid userId = team!.UserId;

        DateTime createdDate = _dateTimeService.Now;

        return PLAYER_IDS.Select(playerId => new TeamPlayerRequest()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
            UserId = userId,
            TeamId = teamId,
            PlayerId = playerId,
            StatusId = status,
            TeamComment = status == RequestStatusEnum.Declined ? "Seed player comment" : null,
            PlayerComment = "Seed request"
        });
    }

    private Task PublishTeamPlayerRequestsSeededEventAsync(IEnumerable<TeamPlayerRequest> requests, CancellationToken cancellationToken = default)
    {
        TeamPlayerRequestsSeeded @event = _mapper.Map<TeamPlayerRequestsSeeded>(requests);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}