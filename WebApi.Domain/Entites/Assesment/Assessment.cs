using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Assesment
{
    public class Assessment:BaseEntity
    {
        public string name { get; set; } = "";
        public string? content { get; set; }
        public string? description { get; set; }
        public string? test_tutorial { get; set; }
        public string? slug { get; set; }
        public string? avatar { get; set; }
        public string? columns { get; set; }
        public int? type_code { get; set; }
        public int? sale_code { get; set; }
        public int? status { get; set; }
       
        public int? test_time { get; set; }
        public int? original_price { get; set; }
        public int? assessment_type { get; set; }
    }
}
