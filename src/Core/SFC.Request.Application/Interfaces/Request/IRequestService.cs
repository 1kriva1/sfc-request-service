namespace SFC.Request.Application.Interfaces.Request;
public interface IRequestService
{
    Task NotifyRequestCreatedAsync(RequestEntity request, CancellationToken cancellationToken = default);

    Task NotifyRequestUpdatedAsync(RequestEntity request, CancellationToken cancellationToken = default);
}