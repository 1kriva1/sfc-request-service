using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Request.Application.Interfaces.Request;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;
using SFC.Request.Messages.Commands.Request;

namespace SFC.Request.Infrastructure.Consumers.Request.Domain.Request.Seed;
public class RequireRequestsSeedConsumer(
    ILogger<RequireRequestsSeedConsumer> logger,
    IMapper mapper,
    IRequestSeedService ganeralTemplateSeedService) : IConsumer<RequireRequestsSeed>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<RequireRequestsSeedConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IRequestSeedService _ganeralTemplateSeedService = ganeralTemplateSeedService;

    public async Task Consume(ConsumeContext<RequireRequestsSeed> context)
    {
        RequireRequestsSeed message = context.Message;

        IEnumerable<RequestEntity> requests = await _ganeralTemplateSeedService.GetSeedRequestsAsync().ConfigureAwait(true);

        SeedRequests command = _mapper.Map<SeedRequests>(requests)
                                                     .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireRequestsSeedDefinition : ConsumerDefinition<RequireRequestsSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Request.Value.Domain.Request.Seed.RequireSeed; } }

    public RequireRequestsSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.requests.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireRequestsSeedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.team.teams.seed.require"
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}