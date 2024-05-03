using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Assesment
{
    public class assessment_test_results:BaseEntity
    {
        public string? assessment_id { get; set; }
        public string? user_id { get; set; }                                                                    
        public string? result {  get; set; }
        public int? suggestion_id {  get; set; } 
    }
}
