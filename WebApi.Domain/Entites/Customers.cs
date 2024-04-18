using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class Customers :BaseEntity<Guid>
    {
        public string? name { get; set; }
        public string? customer_id {  get; set; }   
        public string? phoneNumber { get; set; }
        public int? type { get; set; }
        public DateTime? birthday { get; set; }
        public string? note {  get; set; }  
        public string? taxcode { get; set; }
        public int? status { get; set; }
        public string? email { get; set; }
        public int? gender { get; set; }
        public DateTime? lastEngagementDate { get; set; }


    }
}
