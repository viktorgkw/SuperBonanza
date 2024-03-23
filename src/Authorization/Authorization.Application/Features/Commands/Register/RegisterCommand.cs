using Authorization.Domain.Entities;
using Authorization.Domain.Enums;
using MediatR;

namespace Authorization.Application.Features.Commands.Register;

public class RegisterCommand : IRequest<RegisterStatus>
{
    public RegisterModel RegisterModel { get; set; }
}