using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AutoMapper;

using WebApi.Application.Contracts.Persistence;


namespace WebApi.Application.Extensions
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddMediatRModule(this IServiceCollection services, IConfiguration config)
        {
          

            return services;
        }
    }
}
