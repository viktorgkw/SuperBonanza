using Authorization.Application.Features.Commands.Register;
using FluentValidation;

namespace Authorization.Application.Validations.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.RegisterModel.UserName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("UserName is required!");

        RuleFor(x => x.RegisterModel.Password)
           .NotEmpty()
           .NotNull()
           .MinimumLength(4)
           .MaximumLength(18)
           .WithMessage("Password is required!");

        RuleFor(x => x.RegisterModel.FirstName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("FirstName is required!");

        RuleFor(x => x.RegisterModel.LastName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("LastName is required!");

        RuleFor(x => x.RegisterModel.BirthDate)
            .NotNull()
            .WithMessage("BirthDate is required!");
    }
}