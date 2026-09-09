using SFC.Request.Application.Common.Dto.Data;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Game.Data;

namespace SFC.Request.Application.Features.Game.Data.Common.Dto;
public class GameStatusDto : DataDto, IMapTo<GameStatus> { }