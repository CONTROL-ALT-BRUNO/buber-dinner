using BuberDinner.Domain.Common.User;

namespace BuberDinner.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        User? GetUserById(Guid id);
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(Guid id);
    }
}