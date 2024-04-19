using WebApi.Wrappers.DTOS.EmailDtos;

namespace WebApi.Configurations
{
    public static class EmailConfig
    {
        public static void AddMailModule(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
         
        }
    }
}
