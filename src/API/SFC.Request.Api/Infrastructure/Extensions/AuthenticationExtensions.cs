using Microsoft.AspNetCore.Authentication.JwtBearer;

using SFC.Request.Api.Infrastructure.Authentication;
using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Settings;

namespace SFC.Request.Api.Infrastructure.Extensions;

public static class AuthenticationExtensions
{
    private const string ValidJwtHeaderTyp = "at+jwt";

    public static void AddAuthentication(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        IdentitySettings identitySettings = builder.Configuration.GetIdentitySettings();

        builder.Services.AddSingleton<AuthenticationJwtBearerEvents>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
             {
                 if (builder.Environment.IsProduction() || builder.Configuration.UseAuthentication())
                 {
                     options.Authority = identitySettings.Authority;
                     options.Audience = identitySettings.Audience;
                     options.TokenValidationParameters = new()
                     {
                         ValidateAudience = true,
                         NameClaimType = "name",
                         ValidTypes = [ValidJwtHeaderTyp]
                     };
                 }

                 options.EventsType = typeof(AuthenticationJwtBearerEvents);
             }
         );

        builder.Services.AddAuthorization(options =>
        {
            options.AddGeneralPolicy(identitySettings.RequireClaims);
            options.AddOwnRequestPolicy(identitySettings.RequireClaims);
            options.AddOwnPlayerPolicy(identitySettings.RequireClaims);
            options.AddOwnTeamPolicy(identitySettings.RequireClaims);
        });
    }
}