using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Metadata;
public class MetadataState : EnumEntity<MetadataStateEnum>
{
    public MetadataState() : base() { }

    public MetadataState(MetadataStateEnum enumType) : base(enumType) { }
}