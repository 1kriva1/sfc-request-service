using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;

using SFC.Player.Messages.Events.Player.General;
using SFC.Request.Application.Features.Player.Commands.Create;
using SFC.Request.Application.Interfaces.Persistence.Repository.Player;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Player.Domain.Player.Events;
public class PlayerCreatedConsumer(
    IMapper mapper,
    ISender mediator,
    IPlayerRepository playerRepository) : IConsumer<PlayerCreated>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;
    private readonly IPlayerRepository _playerRepository = playerRepository;

    public async Task Consume(ConsumeContext<PlayerCreated> context)
    {
        PlayerCreated @event = context.Message;

        bool playerExist = await _playerRepository.AnyAsync(@event.Player.Id)
                                                  .ConfigureAwait(true);

        if (!playerExist)
        {
            CreatePlayerCommand command = _mapper.Map<CreatePlayerCommand>(@event);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class PlayerCreatedConsumerDefinition : ConsumerDefinition<PlayerCreatedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Player.Value.Domain.Player.Events.Created; } }

    public PlayerCreatedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.player.created.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<PlayerCreatedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.player.created"
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}