using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AutoMapper;
using WebApi.Application.Contracts.Persistence;
using WebApi.Configurations;
using WebApi.Modules.User.Domain.Entites;
using WebApi.Modules.User.Infrastructure.Persistence;
using WebApi.Modules.User.Infrastructure.Persistence.Repositories;


namespace WebApi.Modules.User.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureUser(this IServiceCollection services, IConfiguration config)
        {
            // Đăng kí automapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            //// Đăng kí mediatR
            //services.AddMediatR(typeof(LicenseDetailQuery).Assembly);


            //// Đăng kí repository
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            services.AddScoped<JWTSettings>();
            services.AddScoped<SignInManager<UserIdentity>, CustomSignInManager>();

            //Đăng kí service

            return services;
        }
    }
}

