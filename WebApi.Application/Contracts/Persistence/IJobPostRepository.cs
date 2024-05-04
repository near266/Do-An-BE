using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Contracts.Persistence
{
    public interface IJobPostRepository : IGenericRepository<job_posts>
    {
    }
}
