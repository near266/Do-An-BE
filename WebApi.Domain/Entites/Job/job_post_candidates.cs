using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Domain.Entites.Job
{
    public class job_post_candidates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? job_post_id { get; set; }
        public string? user_id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? cv_path { get; set; }
        public int? status_id { get; set; }
        public DateTime? created_at { get; set; }
    }
}
