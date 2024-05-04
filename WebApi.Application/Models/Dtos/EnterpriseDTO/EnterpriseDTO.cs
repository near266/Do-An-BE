﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Models.Dtos.EnterpriseDTO
{
    public class EnterpriseDTO
    {
        public string? Id { get; set; }
        public string name { get; set; }
        public string? account_id { get; set; }
        public string? abbreviation_name { get; set; }
        public string phone { get; set; }
        public DateTime? phone_verified_at { get; set; }
        public int? career_field_id { get; set; }
        public string? website_url { get; set; }
        public string? introduce { get; set; }
        public int? scale_id { get; set; }
        public int city_id { get; set; }
        public int district_id { get; set; }
        public int? ward_id { get; set; }
        public string address { get; set; }
        public string? map_url { get; set; }
        public int? job_post_count { get; set; }
        public string? business_license_key { get; set; }
        public string? authorization_letter_key { get; set; }
        public int approve_status_id { get; set; }
        public string? reason_of_rejection { get; set; }
        public int receive_news { get; set; }

        public string? pricing_plan_id { get; set; }
        public DateTime? pricing_plan_start_at { get; set; }
        public DateTime? pricing_plan_end_at { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string? update_by { get; set; }
        public DateTime? update_at { get; set; }
    }
}

