using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Domain.Entities.Player;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Player;
public class PlayerTagConfiguration : IEntityTypeConfiguration<PlayerTag>
{
    public void Configure(EntityTypeBuilder<PlayerTag> builder)
    {
        builder.Property(e => e.Value)
               .HasMaxLength(ValidationConstants.TagValueMaxLength)
               .IsRequired(true);

        builder.ToTable("Tags", DatabaseConstants.PlayerSchemaName);
    }
}