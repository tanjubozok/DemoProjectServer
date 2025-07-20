using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DemoProjectServer.Application;

public static class RegistrarServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configurations =>
        {
            configurations.RegisterServicesFromAssembly(typeof(RegistrarServices).Assembly);
            configurations.AddOpenBehavior(typeof(Behaviors.ValidationBehavior<,>));
            configurations.AddOpenBehavior(typeof(Behaviors.PermissionBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(RegistrarServices).Assembly);


        return services;
    }
}
