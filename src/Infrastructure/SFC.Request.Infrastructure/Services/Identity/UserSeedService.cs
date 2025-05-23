using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Identity.Messages.Commands.User;
using SFC.Request.Application.Interfaces.Identity;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Services.Identity;
public class UserSeedService(IBus bus, IConfiguration configuration) : IUserSeedService
{
    private readonly IBus _bus = bus;
    private readonly IConfiguration _configuration = configuration;

    public async Task SendRequireUsersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireUsersSeed command = new() { Initiator = settings.Exchanges.Request.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}