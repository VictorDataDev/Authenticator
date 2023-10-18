using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.ComponentModel;

namespace Api.Auth.Modules
{
    public static class AuthorizationModule
    {
        public static IServiceCollection AddAuthorizationModule(this IServiceCollection services)
        {
            services.AddAuthorization(
                x =>
                {
                    x.AddPolicy("admin", policy => policy.RequireRole("manager"));
                    x.AddPolicy("employee", policy => policy.RequireRole("employee"));
                });

            return services;
        }

    }
}
