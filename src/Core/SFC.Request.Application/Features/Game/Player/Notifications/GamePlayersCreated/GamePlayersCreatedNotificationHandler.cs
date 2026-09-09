using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Application.Interfaces.Request.Game.Player;
using SFC.Request.Domain.Events.Game.Player;

namespace SFC.Request.Application.Features.Game.Player.Notifications.GamePlayersCreated;
public class GamePlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGamePlayerRequestSeedService gamePlayerRequestSeedService) : INotificationHandler<GamePlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGamePlayerRequestSeedService _gamePlayerRequestSeedService = gamePlayerRequestSeedService;

    public async Task Handle(GamePlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GamePlayer, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Request, MetadataDomainEnum.GamePlayerRequest, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _gamePlayerRequestSeedService.SeedGamePlayerRequestsAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}