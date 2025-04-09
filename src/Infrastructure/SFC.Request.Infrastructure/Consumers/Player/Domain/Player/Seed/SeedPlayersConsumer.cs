﻿using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Player.Messages.Commands.Player;
using SFC.Request.Application.Features.Player.Commands.CreateRange;
using SFC.Request.Application.Interfaces.Persistence.Repository.Player;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Player;
public class SeedPlayersConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<SeedPlayersConsumer> logger,
    ISender mediator,
    IPlayerRepository playerRepository) : IConsumer<SeedPlayers>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<SeedPlayersConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IPlayerRepository _playerRepository = playerRepository;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<SeedPlayers> context)
    {
        if (_environment.IsDevelopment())
        {
            SeedPlayers message = context.Message;

            CreatePlayersCommand command = _mapper.Map<CreatePlayersCommand>(message.Players);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class SeedPlayersConsumerDefinition : ConsumerDefinition<SeedPlayersConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Player.Value.Domain.Player.Seed.Seed; } }

    public SeedPlayersConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.player.players.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedPlayersConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.player.players.seeded"
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = _settings.Exchanges.Request.Key.BuildExchangeRoutingKey(_settings.Exchanges.Player.Key);
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}