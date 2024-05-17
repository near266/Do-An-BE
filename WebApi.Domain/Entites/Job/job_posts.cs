using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Job
{
    public class job_posts : BaseEntity
    {
     
        public string? enterprise_id { get; set; }
        public int? career_field_id { get; set; }
        public string? career_id { get; set; }
        public string? title { get; set; } 
        public string? slug { get; set; }
        public string? city { get; set; }
        public string? district { get; set; }
        public string? address { get; set; }
        public string? map_url { get; set; }
        public string? image_url { get; set; }
        public string? form_of_work { get; set; }
        public string? diploma { get; set; }
        public string? experience { get; set; }
        public string? level { get; set; }
        public string? gender { get; set; }
        public DateTime? deadline { get; set; }
        public string? probationary_period { get; set; }
        public string? salary_type { get; set; }
        public int? salary_min { get; set; }
        public int? salary_max { get; set; }
        public string? overview { get; set; }
        public string? requirement { get; set; }
        public string? benefit { get; set; }
        public string? contact_name { get; set; }
        public string? contact_phone { get; set; }
        public string? contact_email { get; set; }
        public string? status_id { get; set; }
        public string? approve_status_id { get; set; }
        public string? reason_of_view { get; set; }
        public int? total_view { get; set; }
        public int? total_cv { get; set; }
 
        public DateTime? deleted_at { get; set; }

    }
}
