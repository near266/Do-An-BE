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
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
        [MaxLength(100)]
        public string? update_by { get; set; }
        public DateTime? update_at { get; set; }
    }
}
