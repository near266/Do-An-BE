﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Contracts.Persistence
{
    public interface IJob_Post_Candidates : IGenericRepository<job_post_candidates>
    {
    }
}
