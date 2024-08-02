using Dinely.Domain.UserAggregate;

namespace Dinely.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
