using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Player;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Player;
public class PlayerAvailabilityConfiguration : IEntityTypeConfiguration<PlayerAvailability>
{
    public void Configure(EntityTypeBuilder<PlayerAvailability> builder)
    {
        builder.Property(e => e.From)
               .IsRequired(false);

        builder.Property(e => e.To)
               .IsRequired(false);

        builder.HasMany(e => e.Days)
               .WithOne(e => e.Availability)
               .HasForeignKey(DatabaseConstants.PlayerAvailabilityForeignKey);

        builder.ToTable("Availabilities", DatabaseConstants.PlayerSchemaName);
    }
}