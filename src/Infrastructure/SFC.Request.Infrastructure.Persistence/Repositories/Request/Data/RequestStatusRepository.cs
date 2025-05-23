using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Request.Domain.Entities.Request.Data;
using SFC.Request.Infrastructure.Persistence.Contexts;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Request.Data;
public class RequestStatusRepository(RequestDbContext context)
    : RequestDataRepository<RequestStatus, RequestStatusEnum>(context), IRequestStatusRepository
{ }