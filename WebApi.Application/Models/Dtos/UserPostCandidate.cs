using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Models.Dtos
{
    public class UserPostCandidate
    {
        public int? id { get; set; }
        public string? job_post_id { get; set; }
        public string? title { get; set; }
        public string? image_url { get; set; }
        public string? EnterpriseName { get; set; }
        public DateTime? createPost_at { get; set; }
        public string? filedName { get; set; }
        public string? city { get; set; }
        public string? district { get; set; }
        public string? contact_email { get; set; }
        public string? contact_phone { get; set; }
        public string? user_id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? cv_path { get; set; }
        public int? status_id { get; set; }
        public DateTime? created_at { get; set; }

    }
}
