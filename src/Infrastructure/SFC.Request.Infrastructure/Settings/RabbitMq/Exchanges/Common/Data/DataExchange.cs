namespace SFC.Request.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;

public class DataExchange<T>
{
    public DataSourceExchange Source { get; set; } = default!;

    public required T Dependent { get; set; }
}

public class DataExchange
{
    public required DataSourceExchange Source { get; set; }
}