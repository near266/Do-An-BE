﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Wrappers.DTOS.UserInfoDtos
{
    public class RegisterEnterprise

    {
        [Required]
        public string name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string? enterprise_name { get; set; }
        public int? gender_id { get; set; }
        [JsonIgnore]
        public string? account_id { get; set; }
        public string? phone { get; set; }
        public string? city_id { get; set; }
        public bool? receive_news { get; set; }

        public string? district_id { get; set; }
        public string? address { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string? update_by { get; set; }
        public DateTime? update_at { get; set; }



    }
}
