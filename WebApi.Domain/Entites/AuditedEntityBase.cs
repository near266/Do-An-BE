using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class AuditedEntityBase
    {
        [MaxLength(100)]
        public string? Created_by { get; set; }
        public DateTime? Created_date { get; set; }
        [MaxLength(100)]
        public string? Last_modified_by { get; set; }
        public DateTime? Last_modified_date { get; set; }
    }
}
