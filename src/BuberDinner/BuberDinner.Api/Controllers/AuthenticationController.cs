using BubeerDinner.Api.Controllers;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController(ISender mediator) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        RegisterCommand command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthenticationResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        LoginQuery command = new LoginQuery(request.Email, request.Password);

        ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);

        if (authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

        return authResult.Match(
            authResult => Ok(MapAuthenticationResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthenticationResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName ?? string.Empty,
            authResult.User.LastName ?? string.Empty,
            authResult.User.Email ?? string.Empty,
            authResult.Token);
    }
}