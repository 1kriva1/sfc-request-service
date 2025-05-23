using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Request.Domain.Entities.Request.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Request.Data.Cache;
public class RequestStatusCacheRepository(RequestStatusRepository repository, ICache cache)
    : RequestDataCacheRepository<RequestStatus, RequestStatusEnum>(repository, cache), IRequestStatusRepository
{ }