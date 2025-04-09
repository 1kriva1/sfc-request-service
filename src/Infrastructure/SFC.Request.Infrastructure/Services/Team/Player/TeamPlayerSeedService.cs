using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Request.Application.Interfaces.Team.Player;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Team.Player;

namespace SFC.Request.Infrastructure.Services.Team.Player;
public class TeamPlayerSeedService(IConfiguration configuration, IBus bus) : ITeamPlayerSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireTeamPlayersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireTeamPlayersSeed command = new() { Initiator = settings.Exchanges.Request.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}