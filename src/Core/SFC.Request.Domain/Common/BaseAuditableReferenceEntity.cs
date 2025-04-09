using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Common;

/// <summary>
/// For core entities from other services.
/// </summary>
/// <typeparam name="TID">Type for entity identifier.</typeparam>
public abstract class BaseAuditableReferenceEntity<TID> : BaseEntity<TID>, IAuditableReferenceEntity
{
    public DateTime CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public Guid LastModifiedBy { get; set; }
}