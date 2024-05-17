using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Entites.Job;

namespace WebApi.Infrastructure.Persistence.Repositories
{
    public class CustomRepository : ICustomRepository
    {
        private readonly ICustomerSupportDbContext _Db;
        private readonly IMapper _mapper;
        public CustomRepository(ICustomerSupportDbContext Db, IMapper mapper)
        {
            _Db = Db;
            _mapper = mapper;
        }
        public async Task<job_posts> updateV2(job_posts job_Posts)
        {
          var check = await _Db.job_Posts.Where(i=>i.Id==job_Posts.Id).FirstOrDefaultAsync();
            if (check != null)
            {
                var map = _mapper.Map(job_Posts, check);
                await _Db.SaveChangesAsync();
            }
            return check;
        }
    }
}
