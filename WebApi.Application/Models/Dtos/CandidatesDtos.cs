using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Models.Dtos
{
    public class CandidatesDtos
    {
        public int id { get; set; }
        public string? avatar { get; set; }
        public string? job_post_id { get; set; }
        public string? user_id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? cv_path { get; set; }
        public int? status_id { get; set; }
        public string? nameFields { get; set; }
        public DateTime? created_at { get; set; }
    }
}
