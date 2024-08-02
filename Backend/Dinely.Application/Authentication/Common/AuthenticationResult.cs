using Dinely.Domain.UserAggregate;

namespace Dinely.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);

