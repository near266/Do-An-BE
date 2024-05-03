using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Assesment
{
    public  class assessment_questions :BaseEntity
    {
        public string? assessment_id { get; set; }
        public string? content {  get; set; }
        public string? columns {  get; set; }
        public string? question_type {  get; set; } 
    }
}
