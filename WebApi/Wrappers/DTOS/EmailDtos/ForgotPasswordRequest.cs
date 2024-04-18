using System.ComponentModel.DataAnnotations;

namespace WebApi.Wrappers.DTOS.EmailDtos
{
    public class ForgotPasswordRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
