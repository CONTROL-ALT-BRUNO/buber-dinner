using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(
    IJwtTokenGenerator tokenGenerator,
    IUserRepository userRepository) : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        if (userRepository.GetUserByEmailAsync(email) is not User user)
            throw new Exception("User with this email does not exist.");

        if (user.Password != password)
            throw new Exception("Invalid password.");

        string token = tokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (userRepository.GetUserByEmailAsync(email) is not null)
            throw new Exception("User with this email already exists.");

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
