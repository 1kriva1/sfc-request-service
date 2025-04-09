using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Events.Request;
public class RequestUpdatedEvent(RequestEntity entity) : BaseEvent
{
    public RequestEntity Request { get; } = entity;
}