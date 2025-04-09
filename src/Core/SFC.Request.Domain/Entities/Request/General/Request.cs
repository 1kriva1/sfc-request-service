using SFC.Request.Domain.Common;
using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Entities.Request.General;

/// <summary>
/// Core entity of the service.
/// </summary>
public class Request : BaseAuditableEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }
}