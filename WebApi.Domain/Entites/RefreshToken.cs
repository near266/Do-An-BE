using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain.Entites
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public string? Token { get; set; }
        public string? UserId { get; set; }
        public DateTime? IssueAt { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}