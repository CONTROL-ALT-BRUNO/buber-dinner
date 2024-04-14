using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(
    IJwtTokenGenerator tokenGenerator,
    IUserRepository userRepository) : IAuthenticationService
{
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (userRepository.GetUserByEmailAsync(email) is not User user)
            return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;

        if (user.Password != password)
            return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;

        string token = tokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (userRepository.GetUserByEmailAsync(email) is not null)
            return Domain.Common.Errors.Errors.User.DuplicatedEmail;

        User user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        userRepository.CreateUserAsync(user);
        
        string token = tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
