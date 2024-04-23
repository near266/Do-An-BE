using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos;
using WebApi.Domain.Entites;

namespace WebApi.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customers>
    {
        Task<Pagination<CustomerDTO>> GetCustomerList(int Page, int PageSize, string? Id, string? Name, string? PhoneNumber, int? Type, DateTime? FromDate, DateTime? ToDate, string? TeleSalesId);
    }
}
