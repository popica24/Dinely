using Dinely.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Dinely.Application.Authentication.Queries.Login;
public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;


