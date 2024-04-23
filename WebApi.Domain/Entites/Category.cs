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
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = null;
        public string? Title { get; set; }
        public List<string>? Image { get; set; }
        public virtual ICollection<Product_Category>? Product_Categories { get; set; }
    }
}
