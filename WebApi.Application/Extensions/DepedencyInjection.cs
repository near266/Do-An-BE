using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AutoMapper;
using WebApi.Application.Command.CareerFieldC;
using WebApi.Application.Command.EnterpriseC;
using WebApi.Application.Command.JobC;
using WebApi.Application.Command.UserInfoC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Application.Queries.CareeFieldsQ;
using WebApi.Application.Queries.EnterpriseQ;
using WebApi.Application.Queries.Job_postQ;
using WebApi.Application.Queries.UserInfoQ;
using WebApi.Domain.Entites.Account;
using WebApi.Domain.Entites.Job;
using WebApi.Shared.Constants;


namespace WebApi.Application.Extensions
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddMediatRModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IRequestHandler<CreateUserInfoCommand, UserInfoDTO>, CreateCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateUserInfoCommand, UserInfoDTO>, UpdateUserInfoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteUserInfoCommand, int>, DeleteUserInfoCommandHandler>();
            services.AddTransient<IRequestHandler<ViewDetailUserInfoQuery, UserInfoDTO>,ViewDetailUserInfoQueryHandler >();
            services.AddTransient<IRequestHandler<ViewAllUserInfoQuery, PagedList<userInfo>>,ViewAllUserInfoQueryHandler >();


            services.AddTransient<IRequestHandler<CreateEnterpriseCommand, EnterpriseDTO>, CreateEnterpriseCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateEnterpriseCommand, EnterpriseDTO>, UpdateEnterpriseCommandHandler>();
            services.AddTransient<IRequestHandler<ViewDetailEnterpriseQuery, EnterpriseDTO>, ViewDetailEnterpriseQueryHandler>();

            services.AddTransient<IRequestHandler<ViewAllCareerFieldsQuery, Pagination<career_fields>>, ViewAllCareerFieldsQueryHandler>();
            services.AddTransient<IRequestHandler<CreateCareerFieldsCommand, career_fields>, CreateCareerFieldsCommandHandler>();

            services.AddTransient<IRequestHandler<CreateJob_postCommand, job_posts>, CreateJob_postCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateJob_postCommand,job_posts>, UpdateJob_postCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteJob_postCommand, int>, DeleteJob_postCommandHandler>();
            services.AddTransient<IRequestHandler<ViewDetailJob_postQuery, job_posts>, ViewDetailJob_postQueryHandler>();
            services.AddTransient<IRequestHandler<SearchJob_postQuery, Pagination<job_posts>>, SearchJob_postQueryHandler>();

            services.AddTransient<IRequestHandler<SearchCareeByFileldIdQuery, Pagination<career>>, SearchCareeByFileldIdQueryHandler>();
            services.AddTransient<IRequestHandler<UpdateJobPostCommand,job_posts>, UpdateJobPostCommandHandler>();
            services.AddTransient<IRequestHandler<ViewDetailFieldsQuery, career_fields>, ViewDetailFieldsQueryHandler>();
            services.AddTransient<IRequestHandler<ViewDetailCareeQuery, career>, ViewDetailCareeQueryHandler>();

            services.AddTransient<IRequestHandler<AddCandidatePostCommand, job_post_candidates>, AddCandidatePostCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateCandidateCommnad, job_post_candidates>, UpdateCandidateCommnadHandler>();
            services.AddTransient<IRequestHandler<DetailCadidatePostQuery, job_post_candidates>, DetailCadidatePostQueryHandler>();

            services.AddTransient<IRequestHandler<ViewCandidateByEnterpiseQuery, PagedList<CandidatesDtos>>, ViewCandidateByEnterpiseQueryHandler>();
            services.AddTransient<IRequestHandler<ViewEnterrpiseByIdQuery,enterprises> ,ViewEnterrpiseByIdQueryHandler>();

            services.AddTransient<IRequestHandler<UpdateStatusEnterpriseCommand, enterprises>, UpdateStatusEnterpriseCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateStatusUserAccountCommand, userInfo>, UpdateStatusUserAccountCommandHandler>();
            services.AddTransient<IRequestHandler<ViewAllEnterpriseCommand, PagedList<enterprises>>, ViewAllEnterpriseCommandHandler>();
            services.AddTransient<IRequestHandler<ListPostTypeQuery, PagedList<JobListDtos>>, ListPostTypeQueryHandler>();
            services.AddTransient<IRequestHandler<ApproveJobPostCommand, int>, ApproveJobPostCommandHandler>();
            services.AddTransient<IRequestHandler<ViewCandidateUserIdQuery, PagedList<UserPostCandidate>>, ViewCandidateUserIdQueryHandler>();
            services.AddTransient<IRequestHandler<PostForUserQuery, PagedList<UserPostCandidate>>, PostForUserQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteCandidateCommand, int>,DeleteCandidateCommandHandler >();

            return services;
        }
    }
}
