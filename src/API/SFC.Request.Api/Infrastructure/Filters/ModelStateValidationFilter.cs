using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Application.Common.Constants;

namespace SFC.Request.Api.Infrastructure.Filters;

public sealed class ValidationFilterAttribute : ActionFilterAttribute
{
    public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (!context.ModelState.IsValid)
        {
            BaseErrorResponse result;

            if (context.ModelState.Any(e => string.IsNullOrEmpty(e.Key)))
            {
                Dictionary<string, IEnumerable<string>> emptyBodyError = new()
                {
                    {
                        "Body",
                        new List<string> {
                            Localization.RequestBodyRequired
                        }
                    }
                };

                result = new BaseErrorResponse(Localization.ValidationError, emptyBodyError);
            }
            else
            {
                result = new(Localization.ValidationError, context.ModelState
                    .Where(state => state.Value?.ValidationState == ModelValidationState.Invalid)
                    .ToDictionary(
                        state => state.Key,
                        state => state.Value?.Errors.Select(e => e.ErrorMessage) ?? [])
                );
            }

            context.Result = new BadRequestObjectResult(result);
        }

        return base.OnActionExecutionAsync(context, next);
    }
}