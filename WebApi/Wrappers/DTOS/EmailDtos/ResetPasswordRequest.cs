using System.ComponentModel.DataAnnotations;

namespace WebApi.Wrappers.DTOS.EmailDtos
{
    public class ResetPasswordRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
