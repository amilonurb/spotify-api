using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace SpotifyWebAPI.Configurations.Options
{
    public static class SwaggerGenOptionsFactory
    {
        public static Action<SwaggerGenOptions> Create => options =>
        {
            options.OperationFilter<SwaggerDefaultValues>();
        };
    }
}