using CleanArchitecture.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites.Job;

namespace WebApi.Infrastructure.Persistence.Repositories
{
    public class Job_postCandidateRepository(CustomerSupportDatabaseContext context) : GenericRepository<job_post_candidates>(context),IJob_Post_Candidates
    {
    }
}
