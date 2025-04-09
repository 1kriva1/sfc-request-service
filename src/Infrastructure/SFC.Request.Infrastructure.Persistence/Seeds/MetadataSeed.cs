using Microsoft.EntityFrameworkCore;

using SFC.Request.Domain.Entities.Metadata;
using SFC.Request.Infrastructure.Persistence.Extensions;

namespace SFC.Request.Infrastructure.Persistence.Seeds;
public static class MetadataSeed
{
    public static void SeedMetadata(this ModelBuilder builder, bool isDevelopment)
    {
        builder.SeedEnumValues<MetadataService, MetadataServiceEnum>(@enum => new MetadataService(@enum));

        builder.SeedEnumValues<MetadataType, MetadataTypeEnum>(@enum => new MetadataType(@enum));

        builder.SeedEnumValues<MetadataState, MetadataStateEnum>(@enum => new MetadataState(@enum));

        builder.SeedEnumValues<MetadataDomain, MetadataDomainEnum>(@enum => new MetadataDomain(@enum));

        MetadataStateEnum seedState = isDevelopment ? MetadataStateEnum.Required : MetadataStateEnum.NotRequired;

        List<MetadataEntity> metadata = [
            new MetadataEntity { Service = MetadataServiceEnum.Data, Type = MetadataTypeEnum.Initialization, Domain = MetadataDomainEnum.Data, State = MetadataStateEnum.Required },
            new MetadataEntity { Service = MetadataServiceEnum.Identity, Type = MetadataTypeEnum.Seed, Domain = MetadataDomainEnum.User, State = seedState },
            new MetadataEntity { Service = MetadataServiceEnum.Player, Domain = MetadataDomainEnum.Player, Type = MetadataTypeEnum.Seed, State = seedState },
            new MetadataEntity { Service = MetadataServiceEnum.Team, Domain = MetadataDomainEnum.Team, Type = MetadataTypeEnum.Seed, State = seedState },
            new MetadataEntity { Service = MetadataServiceEnum.Team, Domain = MetadataDomainEnum.Data, Type = MetadataTypeEnum.Initialization, State = MetadataStateEnum.Required },
            new MetadataEntity { Service = MetadataServiceEnum.Team, Domain = MetadataDomainEnum.TeamPlayer, Type = MetadataTypeEnum.Seed, State = seedState },
            new MetadataEntity { Service = MetadataServiceEnum.Request, Domain = MetadataDomainEnum.Request, Type = MetadataTypeEnum.Seed, State = seedState }
        ];

        builder.Entity<MetadataEntity>().HasData(metadata);
    }
}