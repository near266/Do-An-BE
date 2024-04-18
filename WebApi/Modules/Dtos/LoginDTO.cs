using System.ComponentModel.DataAnnotations;
namespace WebApi.Modules.Dtos
{
    public class LoginDTO
    {
        [Required]
      
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
