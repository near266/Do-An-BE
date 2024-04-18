using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class Category 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; } = null;
        public string? title { get; set; }  
        public List<string>? image { get; set; }
        public virtual ICollection<Product_Category>? Product_Categories { get; set; }
    }
}
