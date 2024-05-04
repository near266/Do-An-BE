using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entites.Account;

namespace WebApi.Application.Contracts.Persistence
{
    public interface IEnterpriseRepository : IGenericRepository<enterprises>
    {
    }
}
