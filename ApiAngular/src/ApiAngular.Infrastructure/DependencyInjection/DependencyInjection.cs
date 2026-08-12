using System.Collections;
using ApiAngular.Domain.Interfaces;
using ApiAngular.Infrastructure.Persistence;
using ApiAngular.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAngular.Infrastructure.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
       services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICursoRepository, CursoRepository>();

        services.AddScoped<ICursoPrecioRepository, CursoPrecioRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}