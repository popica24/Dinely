using Dinely.Application.Authentication.Common;
using Dinely.Application.Common.Interfaces.Authentication;
using Dinely.Application.Common.Interfaces.Persistance;
using Dinely.Domain.Common.Errors;
using Dinely.Domain.UserAggregate;

using ErrorOr;

using MediatR;

namespace Dinely.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler(IUserRepository _userRepository, IJwtTokenGenerator _jwtTokenGenerator) :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}