using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.WebApi.Extensions.ServiceCollectionExtensions;

public static class AddContextConfigurationExtension
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<DefaultContext>(options =>
        options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
            )
        );

        return services;
    }
}
