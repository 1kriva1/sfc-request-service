using SFC.Request.Domain.Entities.Request.Data;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Request.Data;
public interface IRequestStatusRepository : IRequestDataRepository<RequestStatus, RequestStatusEnum> { }