using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Models.Dtos
{
    public class TeleSaleDTO
    {
        public Guid? Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public string? Email { get; set; }
        public string? Taxcode { get; set; }
        public string? Note { get; set; }
        public int? Status { get; set; }

        public string? Created_by { get; set; }
        public DateTime? Created_date { get; set; } = DateTime.UtcNow;

        public string? Last_modified_by { get; set; }
        public DateTime? Last_modified_date { get; set; }
    }
}
