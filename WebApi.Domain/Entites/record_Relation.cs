using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class record_Relation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid? recordId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? SaleId { get; set; }
        public virtual recordSheet? RecordSheet { get; set; }
        public virtual Customers? Customers { get; set; }
        public virtual TeleSales? TeleSales { get; set; }


    }
}
