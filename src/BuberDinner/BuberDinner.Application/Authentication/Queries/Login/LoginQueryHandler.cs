using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Common.User;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        User? user = await Task.FromResult(userRepository.GetUserByEmail(command.Email));

        if (user is null || user.Password != command.Password)
            return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;

        string token = tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}