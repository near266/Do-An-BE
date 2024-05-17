using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Job
{
    public class career
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? id { get; set; }
        public string? name { get; set; }
        public int? active { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? updated_by { get; set; }
        public string? created_by { get; set; }
        public int? field_id { get; set; }
        public string? image_url { get; set; }
        public string? description { get; set; }
        public string? main_tasks { get; set; }
        public string? required_competency { get; set; }
        public string? additional_competency { get; set; }
        public string? minimum_education { get; set; }
        public string? learning_path { get; set; }
        public string? area_of_expertise { get; set; }
        public string? workplace_example { get; set; }
    }
}
