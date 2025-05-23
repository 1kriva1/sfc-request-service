using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Application.Interfaces.Request.Team.Player;
using SFC.Request.Domain.Events.Team.Player;

namespace SFC.Request.Application.Features.Team.Player.Notifications.TeamPlayersCreated;
public class TeamPlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    ITeamPlayerRequestSeedService requestSeedService) : INotificationHandler<TeamPlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly ITeamPlayerRequestSeedService _requestSeedService = requestSeedService;

    public async Task Handle(TeamPlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Team, MetadataDomainEnum.TeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Request, MetadataDomainEnum.TeamPlayerRequest, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _requestSeedService.SeedTeamPlayerRequestsAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}