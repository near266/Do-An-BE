using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Entites.Account;
using WebApi.Domain.Entites.Job;
using WebApi.Shared.Constants;

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

        public async Task<enterprises> getEnterpriseById(string? id)
        {
            return await _Db.enterprises.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<PagedList<job_post_candidates>> Search(string? enterprise_id, int page, int pageSize)
        {
          var check = await _Db.job_Posts.Where(i=>i.enterprise_id==enterprise_id).ToListAsync();
            var listid = check.Select(i=>i.Id).ToList();
            var post = await _Db.job_post_candidates.Where(i => listid.Contains(i.job_post_id))
                .Skip((page-1)*pageSize).Take(pageSize)
                .OrderByDescending(i=>i.created_at)
                .ToListAsync();
            return new PagedList<job_post_candidates>()
            {
                Page = page,
                PageSize = pageSize,
                Data = post
            };

        }

        public async Task<job_post_candidates> UpdateCandidatePost(job_post_candidates job_post_candidates)
        {
            var check = await _Db.job_post_candidates.Where(i => i.id == job_post_candidates.id).FirstOrDefaultAsync();
            if (check != null)
            {
                var map = _mapper.Map(job_post_candidates, check);
                await _Db.SaveChangesAsync();
            }
            return check;
        }

        public async Task<enterprises> UpdatestatusEnterprise(string accountId, int? status)
        {
           var check =  await _Db.enterprises.FirstOrDefaultAsync(i=>i.account_id==accountId);
            if (check != null)
            {
                check.IsLock = status;
                await _Db.SaveChangesAsync();
            }
            return check;
        }

        public async Task<userInfo> UpdateStatusInfo(string accountId, int? status)
        {
            var check = await _Db.userInfos.FirstOrDefaultAsync(i => i.Account_id==accountId);
            if (check != null)
            {
                check.Lock = status;
                await _Db.SaveChangesAsync();
            }
            return check;
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
