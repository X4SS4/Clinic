namespace ClinicAppInfrastructure.DependecyInjections;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class MediatRExtensions
{
    public static void InitMediatR(this IServiceCollection serviceCollection, Assembly registerServiceAssembly)
    {
        serviceCollection.AddMediatR(configuration => {
            configuration.RegisterServicesFromAssembly(registerServiceAssembly);
        });
    }
}
