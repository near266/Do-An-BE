using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class Product :BaseEntity<Guid>
    {
        public string? product_id { get; set; }
        public string? product_name { get; set; }
        public string? product_description { get; set; }
        public double? product_price { get; set; }
        public double? product_sale_price { get; set; }
        public int? status { get; set; }
        public List<string>? image { get; set; }
        public string? title_video {  get; set; }
        public string? link_video { get;set; }

        public virtual ICollection<Product_Category>? Product_Categories { get; set; }
    }
}
