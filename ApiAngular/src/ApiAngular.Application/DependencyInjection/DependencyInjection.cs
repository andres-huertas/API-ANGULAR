using ApiAngular.Application.Interfaces;
using ApiAngular.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAngular.Application.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<ICursoService, CursoService>();

        return services;
    }
}