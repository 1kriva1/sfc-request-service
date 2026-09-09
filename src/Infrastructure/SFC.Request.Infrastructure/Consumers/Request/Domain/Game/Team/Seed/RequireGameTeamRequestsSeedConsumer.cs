using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Request.Application.Interfaces.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;
using SFC.Request.Messages.Commands.Request.Game.Team;

namespace SFC.Request.Infrastructure.Consumers.Request.Domain.Game.Team.Seed;
public class RequireGameTeamRequestsSeedConsumer(
    ILogger<RequireGameTeamRequestsSeedConsumer> logger,
    IMapper mapper,
    IGameTeamRequestSeedService gameTeamRequestSeedService) : IConsumer<RequireGameTeamRequestsSeed>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<RequireGameTeamRequestsSeedConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamRequestSeedService _gameTeamRequestSeedService = gameTeamRequestSeedService;

    public async Task Consume(ConsumeContext<RequireGameTeamRequestsSeed> context)
    {
        RequireGameTeamRequestsSeed message = context.Message;

        IEnumerable<GameTeamRequest> games = await _gameTeamRequestSeedService.GetSeedGameTeamRequestsAsync().ConfigureAwait(true);

        SeedGameTeamRequests command = _mapper.Map<SeedGameTeamRequests>(games)
                                               .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireGameTeamRequestsSeedDefinition : ConsumerDefinition<RequireGameTeamRequestsSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Request.Value.Domain.Game.Team.Seed.RequireSeed; } }

    public RequireGameTeamRequestsSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.game.team.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireGameTeamRequestsSeedConsumer> consumerConfigurator,
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