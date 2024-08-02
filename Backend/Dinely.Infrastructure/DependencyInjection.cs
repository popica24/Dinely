using System.Text;

using Dinely.Application.Common.Interfaces.Authentication;
using Dinely.Application.Common.Interfaces.Persistance;
using Dinely.Application.Common.Interfaces.Services;
using Dinely.Infrastructure.Authentication;
using Dinely.Infrastructure.Persistance;
using Dinely.Infrastructure.Persistance.Interceptors;
using Dinely.Infrastructure.Persistance.Repositories;
using Dinely.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dinely.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistance();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();


        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<DinelyDbContext>(options =>
            options.UseNpgsql("User ID=postgres;Password=125879;Host=localhost;Port=5433;Database=Dinely")
        );

        services.AddScoped<PublishDomainEventsInterceptor>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }


    public static IServiceCollection AddAuth(
       this IServiceCollection services, ConfigurationManager configuration)
    {

        var JwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, JwtSettings);

        services.AddSingleton(Options.Create(JwtSettings));

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JwtSettings.Issuer,
                ValidAudience = JwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret))
            });

        return services;
    }
}
