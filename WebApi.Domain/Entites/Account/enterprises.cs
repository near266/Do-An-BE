using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Account
{
    public class enterprises:BaseEntity
    {
        public string? name { get; set; }
        public string? account_id { get; set; }
        public string? avatar { get; set; }

        public string? abbreviation_name { get; set; }
        public string? enterprise_name {  get; set; }
        public int? gender_id { get; set; }
        public string phone { get; set; }
        public DateTime? phone_verified_at { get; set; }
        public int? career_field_id { get; set; }
        public string? website_url { get; set; }
        public string? introduce { get; set; }
        public int? scale_id { get; set; }
        public string? city_id { get; set; }
        public string? district_id { get; set; }
        public string? ward_id { get; set; }
        public string? address { get; set; }
        public string? map_url { get; set; }
        public int? job_post_count { get; set; }
        public string? business_license_key { get; set; }
        public string? authorization_letter_key { get; set; }
        public int? approve_status_id { get; set; }
        public string? reason_of_rejection { get; set; }
        public bool? receive_news { get; set; }

        public string? pricing_plan_id { get; set; }
        public DateTime? pricing_plan_start_at { get; set; }
        public DateTime? pricing_plan_end_at { get; set; }
        public int? IsLock {  get; set; }=0;
    }
}
