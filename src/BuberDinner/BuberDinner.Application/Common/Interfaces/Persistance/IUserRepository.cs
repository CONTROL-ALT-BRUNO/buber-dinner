using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmailAsync(string email);
        User? GetUserByIdAsync(Guid id);
        User CreateUserAsync(User user);
        User UpdateUserAsync(User user);
        bool DeleteUserAsync(Guid id);
    }
}