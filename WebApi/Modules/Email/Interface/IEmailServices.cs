using WebApi.Wrappers.DTOS.EmailDtos;

namespace WebApi.Modules.Email.Interface
{
    public interface IEmailServices
    {
        Task SendAsync(EmailRequest request);
    }
}
