using Microsoft.EntityFrameworkCore.Query.Internal;

namespace WebApi.Wrappers.DTOS.EmailDtos
{
    public class EmailSend
    {
        public string? Sub { get; set; }
        public string? body { get; set; }
        public string? to {  get; set; }
    }
    public class MailEnterprise
    {
        public string? enterpriseName { get; set; }
        public string? UserName { get; set; }
        public string? avatar { get; set; }
        public string? Sub { get; set; }
        public string? body { get; set; }
        public string? to { get; set; }
    }
}
