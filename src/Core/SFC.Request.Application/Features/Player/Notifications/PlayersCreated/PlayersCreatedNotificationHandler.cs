using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Request.Application.Interfaces.Game.General;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Application.Interfaces.Team.General;
using SFC.Request.Domain.Events.Player;

namespace SFC.Request.Application.Features.Player.Notifications.PlayersCreated;
public class PlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    ITeamSeedService teamSeedService,
    IGameSeedService gameSeedService) : INotificationHandler<PlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly ITeamSeedService _teamSeedService = teamSeedService;
    private readonly IGameSeedService _gameSeedService = gameSeedService;

    public async Task Handle(PlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Player, MetadataDomainEnum.Player, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Team, MetadataDomainEnum.Team, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                await _teamSeedService.SendRequireTeamsSeedAsync(cancellationToken)
                                      .ConfigureAwait(false);
            }

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.Game, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                await _gameSeedService.SendRequireGamesSeedAsync(cancellationToken)
                                      .ConfigureAwait(false);
            }
        }
    }
}