using System.Text.Json.Serialization;

namespace WebApi.Wrappers.DTOS.UserInfoDtos
{
    public class UpdateEnterpiseRequest
    {
        public string? Id { get; set; }
        [JsonIgnore]
        public string? account_id { get; set; }
        public string? avatar { get; set; }

        public string? abbreviation_name { get; set; }
        public string? phone { get; set; }
        public string? enterprise_name { get; set; }
        public int? gender_id { get; set; }
        public DateTime? phone_verified_at { get; set; }
        public int? career_field_id { get; set; }
        public string? website_url { get; set; }
        public string? introduce { get; set; }
        public int? scale_id { get; set; }
        public string? city_id { get; set; }
        public string? district_id { get; set; }
        public string? ward_id { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string? update_by { get; set; }
        public DateTime? update_at { get; set; }
    }
}
