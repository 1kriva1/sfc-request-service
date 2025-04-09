using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Metadata;
public class MetadataType : EnumEntity<MetadataTypeEnum>
{
    public MetadataType() : base() { }

    public MetadataType(MetadataTypeEnum enumType) : base(enumType) { }
}