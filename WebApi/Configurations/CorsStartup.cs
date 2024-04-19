
using System.Text;
using WebApi.Shared.Constants;

namespace WebApi.Configurations
{
    public static class CorsStartup
    {
        public static IServiceCollection AddCorsModule(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }

        public static IApplicationBuilder UseApplicationCors(this IApplicationBuilder app, IServiceCollection services, IConfiguration configuration)
        {
            string cors = string.Empty;
          
            
                cors = configuration[ConsulKeyConstant.CORS];
            

            if (cors.Equals("*"))
            {
                app.UseCors(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            }
            else
            {
                app.UseCors(builder =>
                {
                    var listCors = cors.Split(',');
                    foreach (var c in listCors)
                    {
                        builder
                        .WithOrigins(c)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    }
                });
            }

            return app;
        }
    }
}
