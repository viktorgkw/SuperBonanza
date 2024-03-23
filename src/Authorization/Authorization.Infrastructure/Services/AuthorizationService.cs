using Authorization.Application.Contracts;
using Authorization.Domain.Entities;
using Authorization.Domain.Enums;
using Authorization.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Infrastructure.Services;

public class AuthorizationService(
    AuthDbContext context,
    IMapper mapper)
    : IAuthorizationService
{
    private readonly AuthDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<RegisterStatus> TryRegisterUser(RegisterModel registerModel, CancellationToken cancellationToken)
    {
        var usernameExists = await _context.Users
            .AnyAsync(u => u.UserName == registerModel.UserName, cancellationToken: cancellationToken);

        if (usernameExists)
            return RegisterStatus.Failed;

        registerModel.Password = BCrypt.Net.BCrypt.HashPassword(registerModel.Password);

        var user = _mapper.Map<AppUser>(registerModel);

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return RegisterStatus.Success;
    }

    public async Task<LoginStatus> TryLoginUser(LoginModel loginModel, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(
            u => u.UserName == loginModel.UserName,
            cancellationToken: cancellationToken);

        if (user is null) return LoginStatus.WrongCredentials;

        bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginModel.Password, user.HashedPassword);

        return isValidPassword ? LoginStatus.Success : LoginStatus.WrongCredentials;
    }
}