using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

using SFC.Request.Application.Interfaces.Persistence.Repository.Data;
using SFC.Request.Domain.Entities.Data;
using SFC.Request.Domain.Events.Data;

namespace SFC.Request.Application.Features.Data.Commands.Reset;

public class ResetDataCommandHandler(
IMapper mapper,
IMediator mediator,
IFootballPositionRepository positionsRepository,
IGameStyleRepository gameStylesRepository,
IStatCategoryRepository statCategoriesRepository,
IStatSkillRepository statSkillsRepository,
IStatTypeRepository statTypesRepository,
IWorkingFootRepository workingFootsRepository) : IRequestHandler<ResetDataCommand>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMediator _mediator = mediator;
    private readonly IFootballPositionRepository _positionsRepository = positionsRepository;
    private readonly IGameStyleRepository _gameStylesRepository = gameStylesRepository;
    private readonly IStatCategoryRepository _statCategoriesRepository = statCategoriesRepository;
    private readonly IStatSkillRepository _statSkillsRepository = statSkillsRepository;
    private readonly IStatTypeRepository _statTypesRepository = statTypesRepository;
    private readonly IWorkingFootRepository _workingFootsRepository = workingFootsRepository;

    public async Task Handle(ResetDataCommand request, CancellationToken cancellationToken)
    {
        FootballPosition[] footballPositions = await _positionsRepository.ResetAsync(_mapper.Map<IEnumerable<FootballPosition>>(request.FootballPositions))
                                                                         .ConfigureAwait(false);

        GameStyle[] gameStyles = await _gameStylesRepository.ResetAsync(_mapper.Map<IEnumerable<GameStyle>>(request.GameStyles))
                                                            .ConfigureAwait(false);

        WorkingFoot[] workingFoots = await _workingFootsRepository.ResetAsync(_mapper.Map<IEnumerable<WorkingFoot>>(request.WorkingFoots))
                                                                  .ConfigureAwait(false);

        await _statCategoriesRepository.ResetAsync(_mapper.Map<IEnumerable<StatCategory>>(request.StatCategories))
                                                                       .ConfigureAwait(false);

        await _statSkillsRepository.ResetAsync(_mapper.Map<IEnumerable<StatSkill>>(request.StatSkills))
                                                            .ConfigureAwait(false);

        StatType[] statTypes = await _statTypesRepository.ResetAsync(_mapper.Map<IEnumerable<StatType>>(request.StatTypes))
                                                         .ConfigureAwait(false);

        await PublishDataResetedEventAsync(footballPositions, gameStyles, workingFoots, statTypes, cancellationToken).ConfigureAwait(false);
    }

    private Task PublishDataResetedEventAsync(
            FootballPosition[] footballPositions,
            GameStyle[] gameStyles,
            WorkingFoot[] workingFoots,
            StatType[] statTypes,
            CancellationToken cancellationToken)
    {
        DataResetedEvent @event = new(footballPositions, gameStyles, workingFoots, statTypes);
        return _mediator.Publish(@event, cancellationToken);
    }
}