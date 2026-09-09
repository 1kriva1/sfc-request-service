using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Events.Game.Player;
using SFC.Request.Application.Features.Game.Player.Commands.Create;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Game.Domain.Player.Events;
public class GamePlayerCreatedConsumer(
    IMapper mapper,
    ILogger<GamePlayerCreatedConsumer> logger,
    ISender mediator) : IConsumer<GamePlayerCreated>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<GamePlayerCreatedConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<GamePlayerCreated> context)
    {
        GamePlayerCreated @event = context.Message;

        CreateGamePlayerCommand command = _mapper.Map<CreateGamePlayerCommand>(@event);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class GamePlayerCreatedConsumerDefinition : ConsumerDefinition<GamePlayerCreatedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Player.Events.Created; } }

    public GamePlayerCreatedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.game.player.created.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<GamePlayerCreatedConsumer> consumerConfigurator,
            IRegistrationContext context)
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