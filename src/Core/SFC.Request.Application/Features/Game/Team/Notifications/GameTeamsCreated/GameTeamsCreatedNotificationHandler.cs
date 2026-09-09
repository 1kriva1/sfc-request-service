using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Application.Interfaces.Request.Game.Team;
using SFC.Request.Domain.Events.Game.Team;

namespace SFC.Request.Application.Features.Game.Team.Notifications.GameTeamsCreated;
public class GameTeamsCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGameTeamRequestSeedService gameTeamRequestSeedService) : INotificationHandler<GameTeamsCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGameTeamRequestSeedService _gameTeamRequestSeedService = gameTeamRequestSeedService;

    public async Task Handle(GameTeamsCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeam, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Request, MetadataDomainEnum.GameTeamRequest, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _gameTeamRequestSeedService.SeedGameTeamRequestsAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}