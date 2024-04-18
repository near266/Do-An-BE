using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace WebApi.Configurations
{
    public static class HealthCheckExtensions
    {
        public static void SetupHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }
        public static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => false
            });
        }
    }
}
