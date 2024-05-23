using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Models.Dtos;
using WebApi.Domain.Entites.Account;
using WebApi.Domain.Entites.Job;
using WebApi.Shared.Constants;

namespace WebApi.Application.Contracts.Persistence
{
    public interface ICustomRepository
    {
        Task<job_posts> updateV2(job_posts job_Posts);
        Task<job_post_candidates> UpdateCandidatePost(job_post_candidates job_post_candidates);
        Task<PagedList<job_post_candidates>> Search( string? enterprise_id,int page , int pageSize);   
        Task<enterprises> getEnterpriseById(string? id);
        Task<enterprises> UpdatestatusEnterprise(string accountId,int? status);
        Task<userInfo> UpdateStatusInfo(string accountId,int? status);   
       
    }
}
