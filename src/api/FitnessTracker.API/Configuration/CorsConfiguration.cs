using FitnessTracker.API.Configuration.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;

namespace FitnessTracker.API.Configuration
{
    public static class CorsConfiguration
    {
        public static void AddCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CorsOptions>(configuration.GetSection("CORS"));

            var corsOptions = configuration.GetSection("CORS").Get<CorsOptions>();

            services.AddCors(options =>
            {
                foreach (var policy in corsOptions.Policies)
                {
                    options.AddPolicy(policy.PolicyName,
                        builder =>
                        {
                            builder.WithOrigins(policy.AllowedOrigins.ToArray())
                                .AllowAnyHeader()
                                .AllowAnyOrigin();
                        });
                }
            });
        }

        public static void UseCors(this IApplicationBuilder app, IOptions<CorsOptions> corsOptions)
        {
            foreach (var policy in corsOptions.Value.Policies)
            {
                app.UseCors(policy.PolicyName);
            }
        }
    }
}
