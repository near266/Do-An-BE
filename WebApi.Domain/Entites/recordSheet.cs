using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites
{
    public class recordSheet : BaseEntity<Guid>
    {
        public string name {  get; set; }
        public int status {  get; set; }
        public int priority {  get; set; }

    }
}
