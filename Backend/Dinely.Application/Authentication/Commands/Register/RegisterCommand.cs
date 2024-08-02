using Dinely.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Dinely.Application.Authentication.Commands.Register;
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;


