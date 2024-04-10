using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) {
        AuthenticationResult authResult = authenticationService.Register(request.FirstName,
                                                                         request.LastName,
                                                                         request.Email,
                                                                         request.Password);

        AuthenticationResponse response = new AuthenticationResponse(authResult.Id,
                                                                     authResult.FirstName,
                                                                     authResult.LastName,
                                                                     authResult.Email,
                                                                     authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request) {
        AuthenticationResult authResult = authenticationService.Login(request.Email,
                                                                      request.Password);

        AuthenticationResponse response = new AuthenticationResponse(authResult.Id,
                                                                     authResult.FirstName,
                                                                     authResult.LastName,
                                                                     authResult.Email,
                                                                     authResult.Token);
        
        return Ok(response);
    }
}   