using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Events.Game.General;
using SFC.Request.Application.Features.Game.General.Commands.Creates;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Game.Domain.Game.Seed;
public class GamesSeededConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<GamesSeededConsumer> logger,
    ISender mediator,
    IMetadataService metadataService) : IConsumer<GamesSeeded>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<GamesSeededConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IMetadataService _metadataService = metadataService;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<GamesSeeded> context)
    {
        if (_environment.IsDevelopment())
        {
            if (await _metadataService.IsCompletedAsync(MetadataServiceEnum.Data, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(true) &&
                await _metadataService.IsCompletedAsync(MetadataServiceEnum.Identity, MetadataDomainEnum.User, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                GamesSeeded @event = context.Message;

                CreatesGameCommand command = _mapper.Map<CreatesGameCommand>(@event.Games);

                await _mediator.Send(command)
                               .ConfigureAwait(false);
            }
        }
    }
}

public class GamesSeededConsumerDefinition : ConsumerDefinition<GamesSeededConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Game.Seed.Seeded; } }

    public GamesSeededConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.game.games.seeded.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<GamesSeededConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}