using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpotifyWebAPI.Application.Services.Common;
using SpotifyWebAPI.Services.HttpClients.Spotify;
using SpotifyWebAPI.Shared.Context;
using System.Reflection;

namespace SpotifyWebAPI.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SpotifyOptions>(configuration.GetSection("Spotify"));

            services.AddHttpClient<IHttpClient<SpotifyHttpClient>, SpotifyHttpClient>();

            services.Scan(scan => scan.FromAssemblies(Assembly.Load("SpotifyWebAPI.Services"))
                                      .AddClasses(c => c.Where(type => type.Name.EndsWith("Service")))
                                      .AsImplementedInterfaces()
                                      .WithScopedLifetime());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IMyHttpContextAccessor, MyHttpContextAccessor>();

            return services;
        }
    }
}