using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Game.Messages.Commands.Game.Team.General;
using SFC.Request.Application.Interfaces.Game.Team;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Services.Game.Team;
public class GameTeamSeedService(IConfiguration configuration, IBus bus) : IGameTeamSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireGameTeamsSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireGameTeamsSeed command = new() { Initiator = settings.Exchanges.Request.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}