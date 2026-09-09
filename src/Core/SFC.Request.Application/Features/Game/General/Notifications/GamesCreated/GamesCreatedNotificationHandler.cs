using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Request.Application.Interfaces.Game.Player;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Domain.Events.Game.General;

namespace SFC.Request.Application.Features.Game.General.Notifications.GamesCreated;
public class GamesCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGamePlayerSeedService gamePlayerSeedService) : INotificationHandler<GamesCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGamePlayerSeedService _gamePlayerSeedService = gamePlayerSeedService;

    public async Task Handle(GamesCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.Game, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GamePlayer, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                if (await _metadataService.IsCompletedAsync(MetadataServiceEnum.Player, MetadataDomainEnum.Player, MetadataTypeEnum.Seed).ConfigureAwait(true))
                {
                    await _gamePlayerSeedService.SendRequireGamePlayersSeedAsync(cancellationToken)
                                                .ConfigureAwait(false);
                }
            }
        }
    }
}