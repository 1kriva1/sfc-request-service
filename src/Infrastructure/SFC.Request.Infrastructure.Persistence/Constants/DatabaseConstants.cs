namespace SFC.Request.Infrastructure.Persistence.Constants;
public static class DatabaseConstants
{
    public const string DefaultSchemaName = "Request";

    public const string DataSchemaName = "Data";

    public const string IdentitySchemaName = "Identity";

    public const string PlayerSchemaName = "Player";

    public const string TeamSchemaName = "Team";

    public const string MetadataSchemaName = "Metadata";

    public const string UserForeignKey = "UserId";

    public const string PlayerForeignKey = "PlayerId";

    public const string PlayerAvailabilityForeignKey = "AvailabilityId";

    public const string TeamForeignKey = "TeamId";
}