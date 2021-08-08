using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SpotifyWebAPI.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyDependencies(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblies(Assembly.Load("SpotifyWebAPI.Services"))
                                      .AddClasses(c => c.Where(type => type.Name.EndsWith("Service")))
                                      .AsImplementedInterfaces()
                                      .WithScopedLifetime());

            return services;
        }
    }
}