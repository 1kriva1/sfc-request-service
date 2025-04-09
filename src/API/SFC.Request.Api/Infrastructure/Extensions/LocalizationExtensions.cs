using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Application;
using SFC.Request.Application.Common.Constants;
using SFC.Request.Infrastructure.Constants;

namespace SFC.Request.Api.Infrastructure.Extensions;

public static class LocalizationExtensions
{
    public static void AddLocalization(this WebApplicationBuilder builder)
    {
        builder.Services.AddLocalization(options => options.ResourcesPath = CommonConstants.ResourcePath);

        builder.Services.Configure<RequestLocalizationOptions>(options => options.SetDefaultCulture(CommonConstants.SupportedCultures[0])
                .AddSupportedCultures(CommonConstants.SupportedCultures)
                .AddSupportedUICultures(CommonConstants.SupportedCultures));
    }

    public static void UseLocalization(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        IOptions<RequestLocalizationOptions> localizationOptions =
            app.Services.GetService<IOptions<RequestLocalizationOptions>>()!;

        app.UseRequestLocalization(localizationOptions.Value);

        // inject localizer explicity for error messages
        IStringLocalizer<Resources> localizer =
            app.Services.GetService<IStringLocalizer<Resources>>()!;

        Localization.Configure(localizer);
    }
}