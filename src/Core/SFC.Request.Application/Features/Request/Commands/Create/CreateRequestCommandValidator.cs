using FluentValidation;

namespace SFC.Request.Application.Features.Request.Commands.Create;
public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
{
    public CreateRequestCommandValidator()
    {
    }
}