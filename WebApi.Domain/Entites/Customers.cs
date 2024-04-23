using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class Customers : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public string? Customer_id { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Type { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Note { get; set; }
        public string? Taxcode { get; set; }
        public int? Status { get; set; }
        public string? Email { get; set; }
        public int? Gender { get; set; }
        public DateTime? LastEngagementDate { get; set; }
    }
}
