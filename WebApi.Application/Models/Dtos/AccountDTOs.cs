using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Models.Dtos
{
    public class AccountDTOs
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? phone { get; set; }  
        public string? email { get; set; }
        public string? avatar { get; set; }
        public int? status { get; set; } = 0;
    }
}
