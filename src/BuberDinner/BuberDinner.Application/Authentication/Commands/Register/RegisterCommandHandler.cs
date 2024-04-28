using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.User;
using BuberDinner.Domain.User.ValueObjects;

using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(
    IJwtTokenGenerator tokenGenerator,
    IUserRepository userRepository) 
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        if (await Task.FromResult(userRepository.GetUserByEmail(command.Email) is not null))
            return Domain.Common.Errors.Errors.User.DuplicatedEmail;

        User user = new User(UserId.CreateUnique()) 
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        userRepository.CreateUser(user);

        string token = tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
