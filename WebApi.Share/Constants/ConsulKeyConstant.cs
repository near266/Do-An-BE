using System.Runtime.Serialization;

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
    public class PagedList<T> where T : class
    {
        [DataMember(Order = 1)]
        public IEnumerable<T> Data { get; set; }

        [DataMember(Order = 2)]
        public int TotalCount { get; set; }

        [DataMember(Order = 3)]
        public int Page { get; set; }

        [DataMember(Order = 4)]
        public int PageSize { get; set; }

        public PagedList()
        {
            Data = new List<T>();
        }

        public PagedList(IEnumerable<T> _Data, int _TotalCount, int _Page, int _PageSize)
        {
            Data = _Data;
            TotalCount = _TotalCount;
            Page = _Page;
            PageSize = _PageSize;
        }
    }
}
