using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class TeleSales : BaseEntity<Guid>
    {
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public string? Email { get; set; }
        public string? Taxcode { get; set; }
        public string? Note { get; set; }
        public int? Status { get; set; }

    }
}
