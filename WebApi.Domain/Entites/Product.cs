using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class Product : BaseEntity<Guid>
    {
        public string? Product_id { get; set; }
        public string? Product_name { get; set; }
        public string? Product_description { get; set; }
        public double? Product_price { get; set; }
        public double? Product_sale_price { get; set; }
        public int? Status { get; set; }
        public List<string>? Image { get; set; }
        public string? Title_video { get; set; }
        public string? Link_video { get; set; }

        public virtual ICollection<Product_Category>? Product_Categories { get; set; }
    }
}
