using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Commands.Game.Team.General;
using SFC.Request.Application.Features.Game.Team.Commands.Creates;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Game.Domain.Team.General.Seed;
public class SeedGameTeamsConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<SeedGameTeamsConsumer> logger,
    ISender mediator,
    IMetadataService metadataService) : IConsumer<SeedGameTeams>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<SeedGameTeamsConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IMetadataService _metadataService = metadataService;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<SeedGameTeams> context)
    {
        if (_environment.IsDevelopment())
        {
            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeam, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                SeedGameTeams message = context.Message;

                CreatesGameTeamCommand command = _mapper.Map<CreatesGameTeamCommand>(message.GameTeams);

                await _mediator.Send(command)
                               .ConfigureAwait(false);
            }
        }
    }
}

public class SeedGameTeamsConsumerDefinition : ConsumerDefinition<SeedGameTeamsConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Team.Team.Seed.Seed; } }

    public SeedGameTeamsConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.game.team.teams.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedGameTeamsConsumer> consumerConfigurator, IRegistrationContext context)
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