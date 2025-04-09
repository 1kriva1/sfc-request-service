namespace SFC.Request.Application.Interfaces.Request;
public interface IRequestSeedService
{
    Task<IEnumerable<RequestEntity>> GetSeedRequestsAsync();

    Task SeedRequestsAsync(CancellationToken cancellationToken = default);
}