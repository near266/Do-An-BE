using AutoMapper;
using CleanArchitecture.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos;
using WebApi.Domain.Entites;

namespace WebApi.Infrastructure.Persistence.Repositories
{
    public class CustomerRepositoty(CustomerSupportDatabaseContext context, IMapper mapper) : GenericRepository<Customers>(context), ICustomerRepository
    {
        private readonly IMapper _mapper = mapper;

        public async Task<Pagination<CustomerDTO>> GetCustomerList(int Page, int PageSize, string? Id, string? Name, string? PhoneNumber, int? Type, DateTime? FromDate, DateTime? ToDate, string? TeleSalesId)
        {
            var query = context.Customers.AsQueryable();
            if (!string.IsNullOrEmpty(Id))
            {
                query = query.Where(x => x.Id.ToString().Contains(Id));
            }
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(x => x.Name != null && x.Name.Contains(Name));
            }
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber != null && x.PhoneNumber.Contains(PhoneNumber));
            }
            if (Type != null)
            {
                query = query.Where(x => x.Type == Type);
            }
            if (FromDate != null && FromDate != DateTime.MinValue)
            {
                query = query.Where(c => c.Created_date >= FromDate);
            }
            if (ToDate != null && ToDate != DateTime.MinValue)
            {
                query = query.Where(c => c.Created_date <= ToDate);
            }
            if (!string.IsNullOrEmpty(TeleSalesId))
            {
                var customer_telesales = context.Customers_TeleSales.Where(x => x.SalesId.ToString() == TeleSalesId).Select(x => x.CustomerId).ToList();
                query = query.Where(x => customer_telesales.Contains(Guid.Parse(x.Customer_id)));
            }
            var customers = query.Skip((Page - 1) * PageSize).Take(PageSize).ToList();
            var pagedList = new Pagination<CustomerDTO>
            {
                Items = _mapper.Map<ICollection<CustomerDTO>>(customers),
                PageIndex = Page,
                PageSize = PageSize,
                TotalItemsCount = context.Customers.Count(),
            };
            return pagedList;

        }
    }
}
