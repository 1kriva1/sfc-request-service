using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Request.Infrastructure.Extensions;

namespace SFC.Request.Infrastructure.Authorization.OwnGame;
public class OwnGameHandler(IGameRepository GameRepository, IHttpContextAccessor httpContextAccessor)
    : AuthorizationHandler<OwnGameRequirement>
{
    private readonly IGameRepository _GameRepository = GameRepository;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnGameRequirement requirement)
    {
        string? gameIdValue = _httpContextAccessor.HttpContext?.GetRouteValue("gameId")?.ToString();

        if (!long.TryParse(gameIdValue, out long GameId))
        {
            context.Fail(new AuthorizationFailureReason(this, "Route does not have \"id\" parameter value."));
            return;
        }

        Guid? userId = _httpContextAccessor.GetUserId();

        if (!userId.HasValue)
        {
            context.Fail(new AuthorizationFailureReason(this, "User does not have NameIdentifier claim value."));
            return;
        }

        if (!await _GameRepository.AnyAsync(GameId, userId.Value).ConfigureAwait(true))
        {
            context.Fail(new AuthorizationFailureReason(this, $"User - {userId} does not related to this resource - {GameId}."));
            return;
        }

        context.Succeed(requirement);
    }
}