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
        public Guid? id { get; set; }
        public string? product_id { get; set; }
        public string? product_name { get; set; }
        public string? product_description { get; set; }
        public double? product_price { get; set; }
        public double? product_sale_price { get; set; }
        public int? status { get; set; }
        public List<string>? image { get; set; }
        public string? title_video { get; set; }
        public string? link_video { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string? last_modified_by { get; set; }
        public DateTime? last_modified_date { get; set; }
    }
}
