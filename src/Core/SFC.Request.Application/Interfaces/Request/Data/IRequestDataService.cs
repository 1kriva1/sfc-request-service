using SFC.Request.Application.Interfaces.Request.Data.Models;

namespace SFC.Request.Application.Interfaces.Request.Data;
public interface IRequestDataService
{
    Task<GetAllRequestDataModel> GetAllRequestDataAsync();

    Task<GetTeamDataModel> GetTeamDataAsync();

    Task<GetGameDataModel> GetGameDataAsync();

    Task PublishDataInitializedEventAsync(CancellationToken cancellationToken);
}