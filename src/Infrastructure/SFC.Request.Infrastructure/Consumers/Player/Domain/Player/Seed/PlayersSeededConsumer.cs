using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using SFC.Player.Messages.Events.Player.General;
using SFC.Request.Application.Features.Player.Commands.CreateRange;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Player.Domain.Player.Seed;
public class PlayersSeededConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ISender mediator,
    IMetadataService metadataService) : IConsumer<PlayersSeeded>
{
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ISender _mediator = mediator;
    private readonly IMetadataService _metadataService = metadataService;

    public async Task Consume(ConsumeContext<PlayersSeeded> context)
    {
        if (_environment.IsDevelopment())
        {
            if (await _metadataService.IsCompletedAsync(MetadataServiceEnum.Data, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(true) &&
                await _metadataService.IsCompletedAsync(MetadataServiceEnum.Identity, MetadataDomainEnum.User, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                PlayersSeeded @event = context.Message;

                CreatePlayersCommand command = _mapper.Map<CreatePlayersCommand>(@event.Players);

                await _mediator.Send(command)
                               .ConfigureAwait(false);
            }
        }
    }
}

public class PlayersSeededConsumerDefinition : ConsumerDefinition<PlayersSeededConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Player.Value.Domain.Player.Seed.Seeded; } }

    public PlayersSeededConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.player.players.seeded.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<PlayersSeededConsumer> consumerConfigurator, IRegistrationContext context)
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
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}