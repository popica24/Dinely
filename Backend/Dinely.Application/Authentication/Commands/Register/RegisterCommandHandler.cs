using Dinely.Application.Authentication.Common;
using Dinely.Application.Common.Interfaces.Authentication;
using Dinely.Application.Common.Interfaces.Persistance;
using Dinely.Domain.Common.Errors;
using Dinely.Domain.UserAggregate;

using ErrorOr;

using MediatR;

namespace Dinely.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler(IUserRepository _userRepository, IJwtTokenGenerator _jwtTokenGenerator) :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            User user = User.Create
            (
                firstName: command.FirstName,
                lastName: command.LastName,
                email: command.Email,
                password: command.Password
            );

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}