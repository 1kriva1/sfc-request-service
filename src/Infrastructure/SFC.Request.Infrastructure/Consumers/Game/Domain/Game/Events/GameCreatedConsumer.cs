using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Events.Game.General;
using SFC.Request.Application.Features.Game.General.Commands.Create;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Game.Domain.Game.Events;
public class GameCreatedConsumer(
    IMapper mapper,
    ILogger<GameCreatedConsumer> logger,
    ISender mediator,
    IGameRepository gameRepository) : IConsumer<GameCreated>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<GameCreatedConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IGameRepository _gameRepository = gameRepository;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<GameCreated> context)
    {
        GameCreated @event = context.Message;

        bool gameExist = await _gameRepository.AnyAsync(@event.Game.Id)
                                                  .ConfigureAwait(true);

        if (!gameExist)
        {
            CreateGameCommand command = _mapper.Map<CreateGameCommand>(@event);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class GameCreatedConsumerDefinition : ConsumerDefinition<GameCreatedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Game.Events.Created; } }

    public GameCreatedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.game.created.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<GameCreatedConsumer> consumerConfigurator,
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