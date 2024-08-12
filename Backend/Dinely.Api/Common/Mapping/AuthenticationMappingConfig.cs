using Dinely.Application.Authentication.Commands.Register;
using Dinely.Application.Authentication.Common;
using Dinely.Application.Authentication.Queries.Login;
using Dinely.Contracts.Authentication;

using Mapster;

namespace Dinely.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);
    }
}
