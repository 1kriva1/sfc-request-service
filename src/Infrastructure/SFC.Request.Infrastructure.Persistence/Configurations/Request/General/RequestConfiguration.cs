using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Identity;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Request.General;
public class RequestConfiguration : AuditableEntityConfiguration<RequestEntity, long>
{
    public override void Configure(EntityTypeBuilder<RequestEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<User>()
               .WithMany()
               .IsRequired(true);

        builder.ToTable("Requests");

        base.Configure(builder);
    }
}