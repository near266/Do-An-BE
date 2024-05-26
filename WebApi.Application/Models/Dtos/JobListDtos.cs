using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Models.Dtos
{
    public class JobListDtos
    {
        public string? id { get; set; }
        public string? entepriseId { get; set; }
        public string? enterpriseName { get; set; }
        public string? fileds { get; set; }
        public string? caree { get; set; }
        public int? approved_status_id {  get; set; }    
        public string? title { get; set; }
        public DateTime? created_at { get; set; }

    }
}
