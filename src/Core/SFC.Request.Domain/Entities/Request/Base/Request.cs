using SFC.Request.Domain.Common;
using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Entities.Request.Base;

/// <summary>
/// Core entity of the service.
/// </summary>
public abstract class Request : BaseAuditableEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public RequestStatusEnum StatusId { get; set; }
}