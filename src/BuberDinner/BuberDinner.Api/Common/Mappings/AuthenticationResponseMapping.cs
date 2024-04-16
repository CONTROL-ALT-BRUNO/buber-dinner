using BuberDinner.Application.Authentication.Common;
using BuberDinner.Contracts.Authentication;

namespace BuberDinner.Api.Common.Mappings;

public static class AuthenticationResponseMapping
{
    public static AuthenticationResponse ToAuthenticationResponse(this AuthenticationResult authResult) => new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName ?? string.Empty, authResult.User.LastName ?? string.Empty, authResult.User.Email ?? string.Empty, authResult.Token);
}