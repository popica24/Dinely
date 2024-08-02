using Dinely.Domain.UserAggregate;

namespace Dinely.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
