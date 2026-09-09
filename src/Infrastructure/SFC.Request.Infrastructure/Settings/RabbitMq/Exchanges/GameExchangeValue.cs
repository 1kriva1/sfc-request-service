using SFC.Request.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;
using SFC.Request.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;

namespace SFC.Request.Infrastructure.Settings.RabbitMq.Exchanges;
public class GameExchangeValue
{
    public DataExchange<GameDataDependentExchange> Data { get; set; } = default!;

    public GameDomainExchange Domain { get; set; } = default!;
}

public class GameDataDependentExchange
{
    public DataDependentExchange Request { get; set; } = default!;
}

public class GameDomainExchange
{
    public DomainExchange<GameDomainEventsExchange> Game { get; set; } = default!;

    public DomainExchange<GamePlayerDomainEventsExchange> Player { get; set; } = default!;

    public GameTeamDomainExchange Team { get; set; } = default!;
}

public class GameTeamDomainExchange
{
    public DomainExchange<GameTeamDomainEventsExchange> Team { get; set; } = default!;
}

public class GameDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

public class GamePlayerDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

public class GameTeamDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}