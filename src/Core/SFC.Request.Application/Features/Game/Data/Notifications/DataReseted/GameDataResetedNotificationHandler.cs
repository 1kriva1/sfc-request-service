using MediatR;

using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Domain.Events.Game.Data;

namespace SFC.Request.Application.Features.Game.Data.Notifications.DataReseted;
public class GameDataResetedNotificationHandler(IMetadataService metadataService)
    : INotificationHandler<GameDataResetedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;

    public async Task Handle(GameDataResetedEvent notification, CancellationToken cancellationToken)
    {
        await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);
    }
}