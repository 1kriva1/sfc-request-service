using SFC.Request.Messages.Commands.Common;

namespace SFC.Request.Messages.Commands.Request;
public class SeedRequests : InitiatorCommand
{
    public IEnumerable<RequestEntity> Requests { get; init; } = [];
}