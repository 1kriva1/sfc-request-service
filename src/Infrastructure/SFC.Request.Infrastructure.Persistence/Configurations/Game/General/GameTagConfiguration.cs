using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Domain.Entities.Game.General;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.General;
public class GameTagConfiguration : IEntityTypeConfiguration<GameTag>
{
    public void Configure(EntityTypeBuilder<GameTag> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Value)
            .HasMaxLength(ValidationConstants.TagValueMaxLength)
            .IsRequired(true);

        builder.ToTable("Tags", DatabaseConstants.GameSchemaName);
    }
}