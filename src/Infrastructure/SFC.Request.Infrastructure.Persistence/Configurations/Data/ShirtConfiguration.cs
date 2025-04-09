using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Data;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Data;
public class ShirtConfiguration : EnumDataEntityConfiguration<Shirt, ShirtEnum>
{
    public override void Configure(EntityTypeBuilder<Shirt> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("Shirts", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}