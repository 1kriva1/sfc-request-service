using AutoMapper;

using MassTransit;

using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request;
using SFC.Request.Application.Interfaces.Request;
using SFC.Request.Messages.Events.Request;

namespace SFC.Request.Infrastructure.Services.Request;
public class RequestSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    IRequestRepository requestRepository) : IRequestSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IRequestRepository _requestRepository = requestRepository;

    #region Stub data

    private static readonly List<long> IDS = [];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<RequestEntity>> GetSeedRequestsAsync()
    {
        //return await _requestRepository.GetByIdsAsync().ConfigureAwait(true);
        return await Task.FromResult<IEnumerable<RequestEntity>>([]).ConfigureAwait(true);
    }

    public async Task SeedRequestsAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<RequestEntity> requests = await CreateSeedRequestsAsync().ConfigureAwait(true);

        RequestEntity[] seedRequests = await
            _requestRepository.AddRangeIfNotExistsAsync([.. requests]).ConfigureAwait(true);

        await PublishRequestsSeededEventAsync(seedRequests, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Request, MetadataDomainEnum.Request, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<RequestEntity>> CreateSeedRequestsAsync()
    {
        List<RequestEntity> result = [];

        foreach (long item in IDS)
        {
            IEnumerable<RequestEntity> part = await BuildRequestAsync(item).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<RequestEntity>> BuildRequestAsync(long id)
    {
        DateTime createdDate = _dateTimeService.Now;

        // TODO
        Guid userId = Guid.NewGuid();

        RequestEntity request = new()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
        };

        return await Task.FromResult(new List<RequestEntity> { request }).ConfigureAwait(true);
    }

    private Task PublishRequestsSeededEventAsync(IEnumerable<RequestEntity> requests, CancellationToken cancellationToken = default)
    {
        RequestsSeeded @event = _mapper.Map<RequestsSeeded>(requests);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}