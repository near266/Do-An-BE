using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Contracts.Persistence
{
    public interface ICustomRepository
    {
        Task<job_posts> updateV2(job_posts job_Posts);
    }
}
