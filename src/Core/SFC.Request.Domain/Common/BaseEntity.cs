using System.ComponentModel.DataAnnotations.Schema;

using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Common;

/// <summary>
/// Main parent class for all entities of ther service.
/// </summary>
/// <typeparam name="TID">Type for entity identifier.</typeparam>
public abstract class BaseEntity<TID> : IEntity
{
    public TID Id { get; set; } = default!;

    private readonly List<BaseEvent> _domainEvents = [];

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public virtual void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public virtual void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public virtual void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}