namespace WebApi.Shared.Constants
{
    public static class ConsulKeyConstant
    {
        public const string PREFIX = "TC_";
        public const string DATABASE = "TC_DatabaseConfiguration.WebApi";
        public const string CORS = PREFIX + "CorsConfiguration";
    }
    public static class ErrorMessage
    {
        public static string NotFoundMessage = "Could not find";
        public static string AppConfigurationMessage = "AppConfiguration cannot be null";
    }
}
