using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;

using SFC.Request.Application.Features.Team.General.Commands.Create;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Events.Team.General;

namespace SFC.Request.Infrastructure.Consumers.Team.Domain.General.Events;
public class TeamCreatedConsumer(
    IMapper mapper,
    ISender mediator,
    ITeamRepository teamRepository) : IConsumer<TeamCreated>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;
    private readonly ITeamRepository _teamRepository = teamRepository;

    public async Task Consume(ConsumeContext<TeamCreated> context)
    {
        TeamCreated @event = context.Message;

        bool teamExist = await _teamRepository.AnyAsync(@event.Team.Id)
                                              .ConfigureAwait(true);

        if (!teamExist)
        {
            CreateTeamCommand command = _mapper.Map<CreateTeamCommand>(@event);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class TeamCreatedConsumerDefinition : ConsumerDefinition<TeamCreatedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Team.Value.Domain.Team.Events.Created; } }

    public TeamCreatedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.team.created.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<TeamCreatedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.team.created"
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}