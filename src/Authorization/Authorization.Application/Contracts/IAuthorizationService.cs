using Authorization.Domain.Entities;
using Authorization.Domain.Enums;

namespace Authorization.Application.Contracts;

public interface IAuthorizationService
{
    Task<RegisterStatus> TryRegisterUser(RegisterModel registerModel, CancellationToken cancellationToken);

    Task<LoginStatus> TryLoginUser(LoginModel loginModel, CancellationToken cancellationToken);
}