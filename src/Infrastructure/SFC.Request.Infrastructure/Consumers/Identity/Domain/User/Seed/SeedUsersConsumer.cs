using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using SFC.Identity.Messages.Commands.User;
using SFC.Request.Application.Features.Identity.Commands.CreateRange;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

using Exchange = SFC.Request.Infrastructure.Settings.RabbitMq.Exchange;

namespace SFC.Request.Infrastructure.Consumers.Identity.Domain.User.Seed;
public class SeedUsersConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ISender mediator) : IConsumer<SeedUsers>
{
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ISender _mediator = mediator;

    public async Task Consume(ConsumeContext<SeedUsers> context)
    {
        if (_environment.IsDevelopment())
        {
            SeedUsers message = context.Message;

            CreateUsersCommand command = _mapper.Map<CreateUsersCommand>(message.Users);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class SeedUsersConsumerDefinition : ConsumerDefinition<SeedUsersConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Identity.Value.Domain.User.Seed.Seed; } }

    public SeedUsersConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.identity.users.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedUsersConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = _settings.Exchanges.Request.Key.BuildExchangeRoutingKey(_settings.Exchanges.Identity.Key);
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}