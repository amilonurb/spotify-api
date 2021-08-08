using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using System;

namespace SpotifyWebAPI.Configurations.Options
{
    public static class ApiVersioningOptionsFactory
    {
        public static Action<ApiVersioningOptions> Create => options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        };
    }
}