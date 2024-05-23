using AutoMapper;
using System.ComponentModel;
using System.Transactions;
using WebApi.Application.Command.CareerFieldC;
using WebApi.Application.Command.JobC;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Application.Queries.Job_postQ;
using WebApi.Domain.Entites.Account;
using WebApi.Domain.Entites.Job;


namespace WebApi.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserInfoDTO, UserInfoDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<userInfo, UserInfoDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<userInfo, userInfo>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));

            CreateMap<enterprises, enterprises>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<enterprises, EnterpriseDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<career_fields, career_fields>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<career_fields, CreateCareerFieldsCommand>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));

            CreateMap<job_posts, job_posts>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));

            CreateMap<CreateJob_postCommand, job_posts>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<UpdateJob_postCommand, job_posts>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<UpdateJob_postCommand, UpdateJob_postCommand>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<UpdateJobPostCommand, job_posts>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<job_post_candidates, job_post_candidates>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<job_post_candidates, AddCandidatePostCommand>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<job_post_candidates, UpdateCandidateCommnad>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));

        }

    }
}
