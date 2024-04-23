using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class Record_Relation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid? RecordId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? SaleId { get; set; }
        public virtual RecordSheet? RecordSheet { get; set; }
        public virtual Customers? Customers { get; set; }
        public virtual TeleSales? TeleSales { get; set; }


    }
}
