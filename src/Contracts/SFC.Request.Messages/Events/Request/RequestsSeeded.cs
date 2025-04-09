namespace SFC.Request.Messages.Events.Request;
public class RequestsSeeded
{
    public IEnumerable<RequestEntity> Requests { get; init; } = [];
}