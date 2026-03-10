using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Request.Domain.Entities.Request.Data;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Request.Data.Cache;
public class RequestStatusCacheRepository(RequestStatusRepository repository, [FromKeyedServices(CacheInstance.Request)] ICache cache)
    : RequestDataCacheRepository<RequestStatus, RequestStatusEnum>(repository, cache), IRequestStatusRepository
{ }