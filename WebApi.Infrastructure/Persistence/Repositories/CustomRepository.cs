using Amazon.Runtime.Internal.Transform;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
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

        public async Task<int> ApproveCandidate(int id, int status)
        {
            var check = await _Db.job_post_candidates.FirstOrDefaultAsync(i => i.id == id);
            if (check == null)
            {
                check.status_id=status;
                await _Db.SaveChangesAsync();
            }
            return status;
        }

        public async Task<int> ApprovePost(string id,int type)
        {
            var check = await _Db.job_Posts.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (check == null)
            {
                return 0;
            }
            check.approve_status_id = type;
            await _Db.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteCandidate(int id)
        {
           var check = await _Db.job_post_candidates.Where(i=>i.id == id).FirstOrDefaultAsync();    
            if(check == null)
            {
                _Db.job_post_candidates.Remove(check);
                await _Db.SaveChangesAsync();
                return 1;
                
            }
            return 0;
        }

        public async Task<PagedList<job_post_candidates>> getCandidateByUserId(string? tilte, int? fileds_id, string userId, int page, int pageSize)
        {
            var qr = _Db.job_post_candidates.AsQueryable();
            if (tilte != null)
            {
            var job = await _Db.job_Posts.Where(i => i.title.Contains(tilte)).ToListAsync();

                var ids = job.Select(i=>i.Id).ToList();
                qr = qr.Where(i => ids.Contains(i.job_post_id));

            }
            if(fileds_id != null)
            {
                var jobC = await _Db.job_Posts.Where(i => i.career_field_id==fileds_id).ToListAsync();

                var idsC = jobC.Select(i=>i.Id).ToList();
                qr = qr.Where(i => idsC.Contains(i.job_post_id));


            }
           var res = qr.Skip((page-1)*pageSize).Take(pageSize).OrderByDescending(i=>i.created_at).ToList();
            return new PagedList<job_post_candidates>()
            {
                TotalCount = qr.Count(),
                Page = page,
                PageSize = pageSize,
                Data = res
            };
        } 

        public async Task<career> GetCareerById(string id)
        {
           var check = await _Db.careers.FirstOrDefaultAsync(i=>i.id == id);
            return check;
        }

        public async Task<career_fields> GetCareerFieldsById(int id)
        {
            return await _Db.career_Fields.FirstOrDefaultAsync(i => i.id == id);
        }

        public async Task<enterprises> getEnterpriseById(string? id)
        {
            return await _Db.enterprises.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<userInfo> GetInfoUserId(string id)
        {
           var user= await _Db.userInfos.FirstOrDefaultAsync(i=>i.Account_id == id);
            return user;
        }

        public async Task<job_posts> GetJobPostsById(string id)
        {
            return await _Db.job_Posts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<PagedList<job_posts>> PostForuser(int? fields, string? city, string? district, int page, int pageSize)
        {
          var qr = _Db.job_Posts.Where(i=>i.approve_status_id==2).AsQueryable();
            if (fields != null)
            {
                qr=qr.Where(i=>i.career_field_id==fields);  
            }
            if (city != null)
            {
                qr = qr.Where(i => i.city == city);
            }
            if (city != null&& district != null)
            {
                qr=qr.Where(i=>i.city == city&&i.district==district);
            }
            var res= qr.Skip((page-1)*pageSize).Take(pageSize).OrderByDescending(i=>i.created_date).ToList();
            return new PagedList<job_posts>()
            {
                Data = res,
                Page = page,
                PageSize = pageSize,
                TotalCount = qr.Count(),
            };
        }

        public async Task<PagedList<job_post_candidates>> Search(int? idFields, string? enterprise_id, int page, int pageSize)
        {
          var check = await _Db.job_Posts.Where(i=>i.enterprise_id==enterprise_id).ToListAsync();
            if (idFields != null)
            {
                check=check.Where(i=>i.career_field_id==idFields).ToList();

            }
            var listid = check.Select(i=>i.Id).ToList();
            var ls = await _Db.job_post_candidates.ToListAsync();
            var post = await _Db.job_post_candidates.Where(i => listid.Contains(i.job_post_id))
                .Skip((page-1)*pageSize).Take(pageSize)
                .OrderByDescending(i=>i.created_at)
                .ToListAsync();
            return new PagedList<job_post_candidates>()
            {
                Page = page,
                TotalCount= ls.Count,
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

        public async Task<PagedList<job_posts>> ViewAllPostByType(int type, int page, int pageSize)
        {
            if (type == 1)
            {

            var ls = await _Db.job_Posts.Where(i=>i.approve_status_id==type).Take(pageSize).Skip((page - 1) * pageSize).OrderByDescending(i=>i.created_date).ToListAsync();
                return new PagedList<job_posts>()
                {
                    Data = ls,
                    TotalCount = ls.Count,
                    Page = page,
                    PageSize = pageSize

                };
            }
            if(type == 2)
            {
                var ls2 = await _Db.job_Posts.Where(i => i.approve_status_id == 2 || i.approve_status_id==3).Take(pageSize).Skip((page - 1) * pageSize).OrderByDescending(i => i.created_date).ToListAsync();
                return new PagedList<job_posts>()
                {
                    Data = ls2,
                    TotalCount = ls2.Count,
                    Page = page,
                    PageSize = pageSize

                };
            }
            return new PagedList<job_posts>()
            {
                

            };
        }

        public async Task<PagedList<enterprises>> ViewListEnterprise(int status, int page, int pageSize)
        {
            var ls = await _Db.enterprises.Where(i=>i.IsLock==status) .Take(pageSize).Skip((page-1)*pageSize).OrderByDescending(i=>i.created_date).ToListAsync();
            return new PagedList<enterprises>() {
            Data = ls,
            TotalCount=ls.Count,
            Page = page,
            PageSize = pageSize
            
            };
        }

        public async Task<PagedList<userInfo>> ViewListUserInfo(int status, int page, int pageSize)
        {
            var ls = await _Db.userInfos.Where(i => i.Lock == status).Take(pageSize).Skip((page - 1) * pageSize).OrderByDescending(i => i.created_date).ToListAsync();
            return new PagedList<userInfo>()
            {
                Data = ls,
                TotalCount = ls.Count,
                Page = page,
                PageSize = pageSize

            };
        }
    }
}
