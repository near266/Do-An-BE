using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Account
{
    public class userInfo : BaseEntity
    {
       public string? Address {  get; set; }
        public string? avatar { get; set; }
       public Guid? Account_id { get; set; }
    }
}
