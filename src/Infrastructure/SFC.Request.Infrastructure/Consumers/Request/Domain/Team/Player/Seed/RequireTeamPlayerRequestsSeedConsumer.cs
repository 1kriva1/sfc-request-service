using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Request.Application.Interfaces.Request.Team.Player;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;
using SFC.Request.Messages.Commands.Request.Team.Player;

namespace SFC.Request.Infrastructure.Consumers.Request.Domain.Team.Player.Seed;
public class RequireTeamPlayerRequestsSeedConsumer(IMapper mapper, ITeamPlayerRequestSeedService ganeralTemplateSeedService)
    : IConsumer<RequireTeamPlayerRequestsSeed>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRequestSeedService _ganeralTemplateSeedService = ganeralTemplateSeedService;

    public async Task Consume(ConsumeContext<RequireTeamPlayerRequestsSeed> context)
    {
        RequireTeamPlayerRequestsSeed message = context.Message;

        IEnumerable<TeamPlayerRequestEntity> requests = await _ganeralTemplateSeedService.GetSeedTeamPlayerRequestsAsync().ConfigureAwait(true);

        SeedTeamPlayerRequests command = _mapper.Map<SeedTeamPlayerRequests>(requests)
                                      .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireTeamPlayerRequestsSeedDefinition : ConsumerDefinition<RequireTeamPlayerRequestsSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Request.Value.Domain.Team.Player.Seed.RequireSeed; } }

    public RequireTeamPlayerRequestsSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.team.player.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireTeamPlayerRequestsSeedConsumer> consumerConfigurator,
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