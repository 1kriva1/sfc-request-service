using AutoMapper;

using MassTransit;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Request.Application.Interfaces.Request.Data;
using SFC.Request.Application.Interfaces.Request.Data.Models;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Messages.Events.Request.Data;

namespace SFC.Request.Infrastructure.Services.Request.Data;
public class RequestDataService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IRequestStatusRepository requestStatusesRepository) : IRequestDataService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IRequestStatusRepository _requestStatusesRepository = requestStatusesRepository;

    public async Task<GetAllRequestDataModel> GetAllRequestDataAsync()
    {
        return new()
        {
            RequestStatuses = await _requestStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task<GetTeamDataModel> GetTeamDataAsync()
    {
        return new()
        {
            RequestStatuses = await _requestStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task PublishDataInitializedEventAsync(CancellationToken cancellationToken)
    {
        GetAllRequestDataModel model = await GetAllRequestDataAsync().ConfigureAwait(true);

        DataInitialized @event = _mapper.BuildRequestDataInitializedEvent(model);

        await _publisher.Publish(@event, cancellationToken)
                        .ConfigureAwait(false);
    }
}