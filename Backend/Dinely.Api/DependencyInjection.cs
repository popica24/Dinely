using Dinely.Api.Common.Errors;
using Dinely.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Dinely.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DinelyProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}
