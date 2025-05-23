using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Request.Data;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Request.Data;
public class RequestStatusConfiguration : EnumDataEntityConfiguration<RequestStatus, RequestStatusEnum>
{
    public override void Configure(EntityTypeBuilder<RequestStatus> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("RequestStatuses", DatabaseConstants.DefaultSchemaName);

        base.Configure(builder);
    }
}