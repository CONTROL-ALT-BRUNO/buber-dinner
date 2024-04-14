using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure;

public class UserRepository : IUserRepository
{
    private static readonly List<User> users = new List<User>();

    public User CreateUser(User user)
    {
        users.Add(user);
        return user;
    }

    public bool DeleteUser(Guid id)
    {
        User? user = users.Find(u => u.Id == id);

        if (user is null)
            return false;

        users.Remove(user);
        return true;
    }

    public User? GetUserByEmail(string email)
    {
        return users.FirstOrDefault(u => u.Email == email);
    }

    public User? GetUserById(Guid id)
    {
        return users.Find(u => u.Id == id);
    }

    public User UpdateUser(User user)
    {
        int index = users.FindIndex(u => u.Id == user.Id);
        users[index] = user;
        return user;
    }
}
