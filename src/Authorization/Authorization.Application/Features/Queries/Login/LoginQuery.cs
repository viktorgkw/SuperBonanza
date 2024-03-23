using Authorization.Domain.Entities;
using Authorization.Domain.Enums;
using MediatR;

namespace Authorization.Application.Features.Queries.Login;

public class LoginQuery : IRequest<LoginStatus>
{
    public LoginModel LoginModel { get; set; }
}