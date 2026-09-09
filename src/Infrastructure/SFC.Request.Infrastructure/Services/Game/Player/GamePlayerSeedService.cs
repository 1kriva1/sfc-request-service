using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Game.Messages.Commands.Game.Player;
using SFC.Request.Application.Interfaces.Game.Player;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Services.Game.Player;
public class GamePlayerSeedService(IConfiguration configuration, IBus bus) : IGamePlayerSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireGamePlayersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireGamePlayersSeed command = new() { Initiator = settings.Exchanges.Request.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}