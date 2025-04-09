using SFC.Request.Application.Interfaces.Cache;
using SFC.Request.Application.Interfaces.Persistence.Repository.Data;
using SFC.Request.Domain.Entities.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Data.Cache;
public class WorkingFootCacheRepository(WorkingFootRepository repository, ICache cache)
    : DataCacheRepository<WorkingFoot, WorkingFootEnum>(repository, cache), IWorkingFootRepository
{ }