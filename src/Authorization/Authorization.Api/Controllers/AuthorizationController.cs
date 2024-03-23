using Authorization.Application.Features.Commands.Register;
using Authorization.Application.Features.Queries.Login;
using Authorization.Domain.Entities;
using Authorization.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorizationController(
    IMediator mediator)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var loginStatus = await _mediator.Send(new LoginQuery { LoginModel = model });

        return loginStatus switch
        {
            LoginStatus.Success => NoContent(),
            LoginStatus.WrongCredentials => BadRequest("Wrong credentials!"),
            _ => Problem("Login failed!")
        };
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var registerStatus = await _mediator.Send(new RegisterCommand { RegisterModel = model });

        return registerStatus switch
        {
            RegisterStatus.Success => NoContent(),
            _ => BadRequest("Registration failed!")
        };
    }
}