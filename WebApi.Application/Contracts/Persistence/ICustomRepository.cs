using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        Task<PagedList<job_post_candidates>> Search(int? idFields, string? enterprise_id,int page , int pageSize);   
        Task<enterprises> getEnterpriseById(string? id);
        Task<enterprises> UpdatestatusEnterprise(string accountId,int? status);
        Task<userInfo> UpdateStatusInfo(string accountId,int? status);   
        Task<PagedList<enterprises>> ViewListEnterprise(int status, int page , int pageSize);
        Task<PagedList<userInfo>> ViewListUserInfo(int status, int page, int pageSize);
        Task<PagedList<job_posts>> ViewAllPostByType(int type,int page,int pageSize);
        Task<int> ApprovePost(string id ,int type);
        Task<career> GetCareerById(string id);
        Task<career_fields> GetCareerFieldsById(int id);
        Task<PagedList<job_post_candidates>> getCandidateByUserId(string? tilte ,int? fileds_id,string userId,int page,int pageSize);
        Task<int> DeleteCandidate(int id);
        Task<int>ApproveCandidate(int id,int status);
        Task<userInfo> GetInfoUserId(string id);
        Task<job_posts> GetJobPostsById(string id);
        Task<PagedList<job_posts>> PostForuser(int? fields,string? city ,string? district ,int page,int pageSize);
       
      


    }
}
