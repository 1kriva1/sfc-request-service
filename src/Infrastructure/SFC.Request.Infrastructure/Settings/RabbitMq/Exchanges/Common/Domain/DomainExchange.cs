namespace SFC.Request.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;
public class DomainExchange<T>
{
    public T Events { get; set; } = default!;

    public DomainSeedExchange Seed { get; set; } = default!;
}