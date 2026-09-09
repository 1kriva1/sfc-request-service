using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Commands.Game.Player;
using SFC.Request.Application.Features.Game.Player.Commands.Creates;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Game.Domain.Player.Seed;
public class SeedGamePlayersConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<SeedGamePlayersConsumer> logger,
    ISender mediator,
    IMetadataService metadataService) : IConsumer<SeedGamePlayers>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<SeedGamePlayersConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IMetadataService _metadataService = metadataService;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<SeedGamePlayers> context)
    {
        if (_environment.IsDevelopment())
        {
            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GamePlayer, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                SeedGamePlayers message = context.Message;

                CreatesGamePlayerCommand command = _mapper.Map<CreatesGamePlayerCommand>(message.GamePlayers);

                await _mediator.Send(command)
                               .ConfigureAwait(false);
            }
        }
    }
}

public class SeedGamePlayersConsumerDefinition : ConsumerDefinition<SeedGamePlayersConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Player.Seed.Seed; } }

    public SeedGamePlayersConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.game.players.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedGamePlayersConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = _settings.Exchanges.Request.Key.BuildExchangeRoutingKey(_settings.Exchanges.Game.Key);
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}