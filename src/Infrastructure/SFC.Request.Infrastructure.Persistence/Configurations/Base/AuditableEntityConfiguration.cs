using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Common;
using SFC.Request.Domain.Common.Interfaces;
using SFC.Request.Domain.Entities.Identity;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Base;

public class AuditableEntityConfiguration<TEntity, TId> : BaseEntityConfiguration<TEntity, TId>
    where TEntity : BaseEntity<TId>, IAuditableEntity
    where TId : struct
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.CreatedDate)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.CreatedBy)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired(true);

        builder.Property(e => e.LastModifiedDate)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.LastModifiedBy)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired(true);

        base.Configure(builder);
    }
}