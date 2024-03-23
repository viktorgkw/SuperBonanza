using Authorization.Domain.Entities;
using FluentValidation;

namespace Authorization.Application.Validations.Entities;

public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
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
    }
}