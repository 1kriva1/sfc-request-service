using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Domain.Entities.Game.General;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.General;

public class GameGeneralProfileConfiguration : IEntityTypeConfiguration<GameGeneralProfile>
{
    public void Configure(EntityTypeBuilder<GameGeneralProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Name)
            .HasMaxLength(ValidationConstants.NameValueMaxLength)
            .IsRequired(true);

        builder.Property(e => e.Description)
            .HasMaxLength(ValidationConstants.DescriptionValueMaxLength)
            .IsRequired(false);

        builder.ToTable("GeneralProfiles", DatabaseConstants.GameSchemaName);
    }
}