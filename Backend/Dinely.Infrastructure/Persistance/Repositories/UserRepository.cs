using Dinely.Application.Common.Interfaces.Persistance;
using Dinely.Domain.UserAggregate;

namespace Dinely.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
