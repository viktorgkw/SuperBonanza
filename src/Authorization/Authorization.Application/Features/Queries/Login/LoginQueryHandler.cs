using Authorization.Application.Contracts;
using Authorization.Domain.Enums;
using MediatR;

namespace Authorization.Application.Features.Queries.Login;

public class LoginQueryHandler(IAuthorizationService authService)
    : IRequestHandler<LoginQuery, LoginStatus>
{
    private readonly IAuthorizationService _authService = authService;

    public async Task<LoginStatus> Handle(
        LoginQuery request,
        CancellationToken cancellationToken)
        => await _authService.TryLoginUser(request.LoginModel, cancellationToken);
}