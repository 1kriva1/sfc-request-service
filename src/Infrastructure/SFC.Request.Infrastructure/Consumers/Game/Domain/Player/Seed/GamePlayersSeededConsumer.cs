using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Events.Game.Player;
using SFC.Request.Application.Features.Game.Player.Commands.Creates;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Game.Domain.Player.Seed;
public class GamePlayersSeededConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<GamePlayersSeededConsumer> logger,
    ISender mediator,
    IMetadataService metadataService) : IConsumer<GamePlayersSeeded>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<GamePlayersSeededConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IMetadataService _metadataService = metadataService;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<GamePlayersSeeded> context)
    {
        if (_environment.IsDevelopment())
        {
            if (await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.Game, MetadataTypeEnum.Seed).ConfigureAwait(true) &&
                await _metadataService.IsCompletedAsync(MetadataServiceEnum.Player, MetadataDomainEnum.Player, MetadataTypeEnum.Seed).ConfigureAwait(true) &&
               !await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GamePlayer, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                GamePlayersSeeded @event = context.Message;

                CreatesGamePlayerCommand command = _mapper.Map<CreatesGamePlayerCommand>(@event.GamePlayers);

                await _mediator.Send(command)
                               .ConfigureAwait(false);
            }
        }
    }
}

public class GamePlayersSeededConsumerDefinition : ConsumerDefinition<GamePlayersSeededConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Player.Seed.Seeded; } }

    public GamePlayersSeededConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.game.players.seeded.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<GamePlayersSeededConsumer> consumerConfigurator, IRegistrationContext context)
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