using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AutoMapper;
using WebApi.Application.Command.EnterpriseC;
using WebApi.Application.Command.UserInfoC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Application.Queries.UserInfoQ;


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
            services.AddTransient<IRequestHandler<ViewAllUserInfoQuery, Pagination<UserInfoDTO>>,ViewAllUserInfoQueryHandler >();


            services.AddTransient<IRequestHandler<CreateEnterpriseCommand, EnterpriseDTO>, CreateEnterpriseCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateEnterpriseCommand, EnterpriseDTO>, UpdateEnterpriseCommandHandler>();

            return services;
        }
    }
}
