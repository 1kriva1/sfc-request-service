using FluentValidation;

namespace SFC.Request.Application.Features.Request.Commands.Update;
public class UpdateRequestCommandValidator : AbstractValidator<UpdateRequestCommand>
{
    public UpdateRequestCommandValidator()
    {
    }
}