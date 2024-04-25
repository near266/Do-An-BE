using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AutoMapper;
using WebApi.Application.Command;
using WebApi.Application.Command.Customer;
using WebApi.Application.Command.Product;
using WebApi.Application.Command.RecordSheet;
using WebApi.Application.Command.TeleSale;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos;
using WebApi.Application.Queries.Customer;
using WebApi.Application.Queries.Product;
using WebApi.Application.Queries.RecordSheet;
using WebApi.Application.Queries.TeleSale;

namespace WebApi.Application.Extensions
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddMediatRModule(this IServiceCollection services, IConfiguration config)
        {
            //// Đăng kí mediatR
            services.AddTransient<IRequestHandler<CreateCustomerCommand, CustomerDTO>, CreateCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateCustomerCommand, CustomerDTO>, UpdateCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteCustomerCommand, int>, DeleteCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<ViewDetailCustomer, CustomerDTO>, ViewDetailCustomerHandler>();
            services.AddTransient<IRequestHandler<ViewListCustomer, Pagination<CustomerDTO>>, ViewListCustomerHandler>();
            //Product
            services.AddTransient<IRequestHandler<CreateProductCommand, ProductDTO>, CreateProductCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateProductCommand, ProductDTO>, UpdateProductCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteProductCommand, int>, DeleteProductCommandHandler>();
            services.AddTransient<IRequestHandler<ViewDetailProductQuery, ProductDTO>, ViewDetailProductQueryHandler>();
            services.AddTransient<IRequestHandler<ViewListProductQuery, Pagination<ProductDTO>>, Queries.Product.ViewListProductQueryHandler>();
            //TeleSale
            services.AddTransient<IRequestHandler<CreateTeleSaleCommand, TeleSaleDTO>, CreateTeleSaleCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateTeleSaleCommand, TeleSaleDTO>, UpdateTeleSaleCommandHandler>();
            services.AddTransient<IRequestHandler<ViewDetailTeleSaleQuery, TeleSaleDTO>, ViewDetailTeleSaleQueryHandler>();
            services.AddTransient<IRequestHandler<ViewListTeleSaleQuery, Pagination<TeleSaleDTO>>, ViewListTeleSaleQueryHandler>();
            //RecordSheet
            services.AddTransient<IRequestHandler<CreateRecordSheetCommand, RecordSheetDTO>, CreateRecordSheetCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateRecordSheetCommand, RecordSheetDTO>, UpdateRecordSheetCommandHandler>();
            services.AddTransient<IRequestHandler<ViewListRecordSheet, Pagination<RecordSheetDTO>>, ViewListRecordSheetHandler>();
            services.AddTransient<IRequestHandler<ViewDetailRecordSheet, RecordSheetDTO>, ViewDetailRecordSheetHandler>();

            return services;
        }
    }
}
