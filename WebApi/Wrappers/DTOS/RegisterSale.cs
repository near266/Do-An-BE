using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Wrappers.DTOS
{
    public class RegisterSale
    {
        [Required]
        public string? UserName {  get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email {  get; set; }
        [JsonIgnore]
        public string? userId { get; set; }
        public string? name { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime? birthday { get; set; }
        public int? gender { get; set; }
        public string? taxcode { get; set; }
        public string? note { get; set; }
        public int? status { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; } = DateTime.Now;

        public string? last_modified_by { get; set; }
        public DateTime? last_modified_date { get; set; }
    }
}
