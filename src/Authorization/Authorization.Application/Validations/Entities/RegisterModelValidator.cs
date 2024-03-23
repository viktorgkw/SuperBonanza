using Authorization.Domain.Entities;
using FluentValidation;

namespace Authorization.Application.Validations.Entities;

public class RegisterModelValidator : AbstractValidator<RegisterModel>
{
    public RegisterModelValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("UserName is required!");

        RuleFor(x => x.Password)
           .NotEmpty()
           .NotNull()
           .WithMessage("Password is required!");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("FirstName is required!");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("LastName is required!");

        RuleFor(x => x.BirthDate)
            .NotNull()
            .WithMessage("BirthDate is required!");
    }
}