using Authorization.Application.Contracts;
using Authorization.Domain.Enums;
using MediatR;

namespace Authorization.Application.Features.Commands.Register;

public class RegisterCommandHandler(
    IAuthorizationService authService)
    : IRequestHandler<RegisterCommand, RegisterStatus>
{
    private readonly IAuthorizationService _authService = authService;

    public async Task<RegisterStatus> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
        => await _authService.TryRegisterUser(request.RegisterModel, cancellationToken);
}