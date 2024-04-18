using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class TeleSales : BaseEntity<Guid>
    {
        public string? userId { get; set; }
        public string? name { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime? birthday { get; set; }
        public int? gender { get; set; }
        public string? email {  get; set; } 
        public string? taxcode { get; set; }
        public string? note { get; set; }
        public int? status { get; set; }   
        
    }
}
