using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Domain.Entities.Request.Data;
using SFC.Request.Infrastructure.Persistence.Extensions;

namespace SFC.Request.Infrastructure.Persistence.Seeds;
public static class RequestDataSeed
{
    public static void SeedRequestData(this ModelBuilder builder, IDateTimeService dateTimeService)
    {
        builder.SeedDataEnumValues<RequestStatus, RequestStatusEnum>(@enum =>
            new RequestStatus(@enum).SetCreatedDate(dateTimeService));
    }
}