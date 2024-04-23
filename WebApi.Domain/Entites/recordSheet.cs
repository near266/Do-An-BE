using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class RecordSheet : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }

    }
}
