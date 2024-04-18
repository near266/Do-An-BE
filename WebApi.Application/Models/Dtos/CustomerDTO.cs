using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Models.Dtos
{
    public class CustomerDTO
    {
        public  Guid? Id { get; set; }  = Guid.NewGuid();
        public string? name { get; set; }
        public string? customer_id { get; set; }
        public string? phoneNumber { get; set; }
        public int? type { get; set; }
        public DateTime? birthday { get; set; }
        public string? note { get; set; }
        public string? taxcode { get; set; }
        public int? status { get; set; }
        public string? email { get; set; }
        public int? gender { get; set; }
        public DateTime? lastEngagementDate { get; set; }

        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
  
        public string? last_modified_by { get; set; }
        public DateTime? last_modified_date { get; set; }
    }
}
