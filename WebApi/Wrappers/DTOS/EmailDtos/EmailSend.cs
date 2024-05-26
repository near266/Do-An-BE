using Microsoft.EntityFrameworkCore.Query.Internal;

namespace WebApi.Wrappers.DTOS.EmailDtos
{
    public class EmailSend
    {
        public string? Sub { get; set; }
        public string? body { get; set; }
        public string? to {  get; set; }
    }
}
