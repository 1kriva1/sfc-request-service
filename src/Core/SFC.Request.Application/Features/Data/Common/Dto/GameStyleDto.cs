using SFC.Request.Application.Common.Dto.Data;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Data;

namespace SFC.Request.Application.Features.Data.Common.Dto;
public class GameStyleDto : DataDto, IMapTo<GameStyle> { }