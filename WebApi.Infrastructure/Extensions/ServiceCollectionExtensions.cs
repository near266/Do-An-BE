﻿

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Application.AutoMapper;

using WebApi.Application.Contracts.Persistence;
using WebApi.Infrastructure.Persistence;
using WebApi.Infrastructure.Persistence.Repositories;


namespace WebApi.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Đăng kí automapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            //// Đăng kí mediatR


            //// Đăng kí repository
          
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IUserInfoRepository), typeof(UserInfoRepository));

            //Đăng kí service

            return services;
        }
    }
}
