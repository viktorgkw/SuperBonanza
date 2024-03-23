using Authorization.Application.Features.Queries.Login;
using FluentValidation;

namespace Authorization.Application.Validations.Queries;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.LoginModel.UserName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("UserName is required!");

        RuleFor(x => x.LoginModel.Password)
           .NotEmpty()
           .NotNull()
           .MinimumLength(4)
           .MaximumLength(18)
           .WithMessage("Password is required!");
    }
}