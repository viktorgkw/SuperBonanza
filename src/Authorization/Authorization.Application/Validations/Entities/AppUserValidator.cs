using Authorization.Domain.Entities;
using FluentValidation;

namespace Authorization.Application.Validations.Entities;

public class AppUserValidator : AbstractValidator<AppUser>
{
    public AppUserValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id is required!");

        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("UserName is required!");

        RuleFor(x => x.HashedPassword)
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