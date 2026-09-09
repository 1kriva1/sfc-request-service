using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Game.Messages.Commands.Request.Data;
using SFC.Request.Application.Interfaces.Request.Data;
using SFC.Request.Application.Interfaces.Request.Data.Models;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings.RabbitMq;

namespace SFC.Request.Infrastructure.Consumers.Game.Data;

public class RequireDataConsumer(IMapper mapper, IRequestDataService requestDataService)
    : IConsumer<RequireData>
{
    private readonly IMapper _mapper = mapper;
    private readonly IRequestDataService _requestDataService = requestDataService;

    public async Task Consume(ConsumeContext<RequireData> context)
    {
        GetGameDataModel model = await _requestDataService.GetGameDataAsync().ConfigureAwait(true);

        InitializeData command = _mapper.BuildInitializeDataCommand(model);

        await context.Send(command).ConfigureAwait(false);
    }
}

public class RequireDataConsumerDefinition : ConsumerDefinition<RequireDataConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Game.Value.Data.Dependent.Request.RequireInitialize; } }

    public RequireDataConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.request.game.data.initialize.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireDataConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}