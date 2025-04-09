using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Metadata;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataDomainConfiguration : EnumEntityConfiguration<MetadataDomain, MetadataDomainEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataDomain> builder)
    {
        builder.ToTable("Domains", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}