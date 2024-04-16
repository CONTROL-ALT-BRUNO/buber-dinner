using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicatedEmail => Error.Conflict(code: "User.DuplicatedEmail", description: "User with this email already exists.");
    }
}