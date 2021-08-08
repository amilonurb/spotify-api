using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SpotifyWebAPI.Configurations.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SpotifyWebAPI.Configurations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(ApiVersioningOptionsFactory.Create);

            services.AddVersionedApiExplorer(ApiExplorerOptionsFactory.Create);

            return services;
        }

        public static IServiceCollection AddMySwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(SwaggerGenOptionsFactory.Create);

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}