using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entites;

namespace WebApi.Application.Contracts.Persistence
{
    public interface ISalesRepository : IGenericRepository<TeleSales>
    {
    }
}
