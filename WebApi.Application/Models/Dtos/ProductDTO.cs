using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Models.Dtos
{
    public class ProductDTO
    {
        public Guid? Id { get; set; }
        public string? Product_id { get; set; }
        public string? Product_name { get; set; }
        public string? Product_description { get; set; }
        public double? Product_price { get; set; }
        public double? Product_sale_price { get; set; }
        public int? Status { get; set; }
        public List<string>? Image { get; set; }
        public string? Title_video { get; set; }
        public string? Link_video { get; set; }
        public string? Created_by { get; set; }
        public DateTime? Created_date { get; set; }
        public string? Last_modified_by { get; set; }
        public DateTime? Last_modified_date { get; set; }
    }
}
