using SFC.Request.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;
using SFC.Request.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;

namespace SFC.Request.Infrastructure.Settings.RabbitMq.Exchanges;
public class RequestExchangeValue
{
    public DataExchange<RequestDataDependentExchange> Data { get; set; } = default!;

    public RequestDomainExchange Domain { get; set; } = default!;
}

public class RequestDataDependentExchange
{
    public DataDependentExchange Data { get; set; } = default!;

    public DataDependentExchange Team { get; set; } = default!;
}

public class RequestDomainExchange
{
    public RequestTeamDomainExchange Team { get; set; } = default!;
}

public class RequestRequestDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

public class RequestTeamDomainExchange
{
    public DomainExchange<RequestTeamPlayerDomainEventsExchange> Player { get; set; } = default!;
}

public class RequestTeamPlayerDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}