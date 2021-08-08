using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;

namespace SpotifyWebAPI.Configurations.Options
{
    public static class ApiExplorerOptionsFactory
    {
        public static Action<ApiExplorerOptions> Create => options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        };
    }
}