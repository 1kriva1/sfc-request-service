using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Data;
using SFC.Request.Domain.Entities.Team.General;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Team.General;
public class TeamShirtConfiguration : IEntityTypeConfiguration<TeamShirt>
{
    public void Configure(EntityTypeBuilder<TeamShirt> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<Shirt>()
               .WithMany()
               .HasForeignKey(t => t.ShirtId)
               .IsRequired(true);

        builder.ToTable("Shirts", DatabaseConstants.TeamSchemaName);
    }
}