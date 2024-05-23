using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Account
{
    public class userInfo : BaseEntity
    {
        public string? name { get; set; }
       public string? address {  get; set; }
        public string? avatar { get; set; }
        public int? gender_id { get; set; }

        public string? birthday {  get; set; }
       public string? Account_id { get; set; }
        public string? phone {  get; set; }
        public string? city_id { get; set; }
        public string? district_id { get; set; }
        public string? ward_id { get; set; }
        public string? information { get; set; }
        public int? Lock { get; set; } = 0; 

    }
}
