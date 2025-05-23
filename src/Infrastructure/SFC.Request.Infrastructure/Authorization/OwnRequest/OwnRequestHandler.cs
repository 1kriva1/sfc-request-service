using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Infrastructure.Extensions;

namespace SFC.Request.Infrastructure.Authorization.OwnRequest;
public class OwnRequestHandler(ITeamPlayerRequestRepository requestRepository, IHttpContextAccessor httpContextAccessor)
    : AuthorizationHandler<OwnRequestRequirement>
{
    private readonly ITeamPlayerRequestRepository _requestRepository = requestRepository;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnRequestRequirement requirement)
    {
        string? requestIdValue = _httpContextAccessor.HttpContext?.GetRouteValue("id")?.ToString();

        if (!long.TryParse(requestIdValue, out long requestId))
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

        if (!await _requestRepository.AnyAsync(requestId, userId.Value).ConfigureAwait(true))
        {
            context.Fail(new AuthorizationFailureReason(this, $"User - {userId} does not related to this resource - {requestId}."));
            return;
        }

        context.Succeed(requirement);
    }
}