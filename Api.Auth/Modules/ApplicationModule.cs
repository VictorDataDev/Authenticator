using Api.Auth.Service.Interface;
using Api.Auth.Service.Tokens;

namespace Api.Auth.Modules
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
