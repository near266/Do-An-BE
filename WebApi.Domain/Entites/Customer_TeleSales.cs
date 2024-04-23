using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class Customer_TeleSales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? SalesId { get; set; }
        public ICollection<Customers>? Customers { get; set; }

        public ICollection<TeleSales>? TeleSales { get; set; }

    }
}
