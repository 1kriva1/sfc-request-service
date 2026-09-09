using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Request.Application.Interfaces.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;
using SFC.Request.Messages.Commands.Request.Game.Player;

namespace SFC.Request.Infrastructure.Consumers.Request.Domain.Game.Player.Seed;
public class RequireGamePlayerRequestsSeedConsumer(
    ILogger<RequireGamePlayerRequestsSeedConsumer> logger,
    IMapper mapper,
    IGamePlayerRequestSeedService gamePlayerRequestSeedService) : IConsumer<RequireGamePlayerRequestsSeed>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<RequireGamePlayerRequestsSeedConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRequestSeedService _gamePlayerRequestSeedService = gamePlayerRequestSeedService;

    public async Task Consume(ConsumeContext<RequireGamePlayerRequestsSeed> context)
    {
        RequireGamePlayerRequestsSeed message = context.Message;

        IEnumerable<GamePlayerRequest> games = await _gamePlayerRequestSeedService.GetSeedGamePlayerRequestsAsync().ConfigureAwait(true);

        SeedGamePlayerRequests command = _mapper.Map<SeedGamePlayerRequests>(games)
                                               .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireGamePlayerRequestsSeedDefinition : ConsumerDefinition<RequireGamePlayerRequestsSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Request.Value.Domain.Game.Player.Seed.RequireSeed; } }

    public RequireGamePlayerRequestsSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.game.player.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireGamePlayerRequestsSeedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}