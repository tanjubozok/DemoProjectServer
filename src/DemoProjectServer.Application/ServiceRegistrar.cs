using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DemoProjectServer.Application;

public static class ServiceRegistrar
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configurations =>
        {
            configurations.RegisterServicesFromAssembly(typeof(ServiceRegistrar).Assembly);
            configurations.AddOpenBehavior(typeof(Behaviors.ValidationBehavior<,>));
            configurations.AddOpenBehavior(typeof(Behaviors.PermissionBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ServiceRegistrar).Assembly);


        return services;
    }
}
