using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Assesment
{
    public class assessment_suggestions:BaseEntity
    {
        public string? assessment_id { get; set; }
        public string? test_result_id { get; set; }
        public string? name {  get; set; }
        public string? content {  get; set; }   
        public int? status { get; set; }
    }
}
