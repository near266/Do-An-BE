using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Models.Dtos.Userinfo
{
    public class UserInfoDTO
    {
        public string? Id { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
        public string? avatar { get; set; }
        public int? gender_id { get; set; }
        public string? information {  get; set; }    

        public string? birthday { get; set; }
        public string? Account_id { get; set; }
        public string? phone { get; set; }
        public string? city_id { get; set; }
        public string? district_id { get; set; }
        public string? ward_id { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
      
        public string? update_by { get; set; }
        public DateTime? update_at { get; set; }
    }
}
