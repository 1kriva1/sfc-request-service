using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Request.Application.Interfaces.Team.General;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Team;
using SFC.Team.Messages.Commands.Team.General;

namespace SFC.Request.Infrastructure.Services.Team.General;
public class TeamSeedService(IConfiguration configuration, IBus bus) : ITeamSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireTeamsSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireTeamsSeed command = new() { Initiator = settings.Exchanges.Request.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}