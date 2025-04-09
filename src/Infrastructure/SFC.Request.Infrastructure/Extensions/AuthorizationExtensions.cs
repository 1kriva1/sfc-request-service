using Microsoft.AspNetCore.Authorization;

using SFC.Request.Infrastructure.Authorization;

namespace SFC.Request.Infrastructure.Extensions;
public static class AuthorizationExtensions
{
    public static void AddGeneralPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        ArgumentNullException.ThrowIfNull(options);

        PolicyModel general = AuthorizationPolicies.General(claims);
        options.AddPolicy(general.Name, general.Policy);
    }

    public static void AddOwnRequestPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownRequest = AuthorizationPolicies.OwnRequest(claims);
        options.AddPolicy(ownRequest.Name, ownRequest.Policy);
    }

    public static void AddOwnPlayerPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownTeam = AuthorizationPolicies.OwnPlayer(claims);
        options.AddPolicy(ownTeam.Name, ownTeam.Policy);
    }

    public static void AddOwnTeamPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownTeam = AuthorizationPolicies.OwnTeam(claims);
        options.AddPolicy(ownTeam.Name, ownTeam.Policy);
    }
}