using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Metadata;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataTypeConfiguration : EnumEntityConfiguration<MetadataType, MetadataTypeEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataType> builder)
    {
        builder.ToTable("Types", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}