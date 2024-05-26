namespace WebApi.Wrappers.DTOS.UserInfoDtos
{
    public class SearchBase
    {
        public int status { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
    public class LockRq
    {
       public string? Id { get; set; }
    }
}
