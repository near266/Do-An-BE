using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Command;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos;

namespace WebApi.Application.Queries.Customer
{
    public class ViewListCustomer : IRequest<Pagination<CustomerDTO>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Type { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? TeleSalesId { get; set; }
    }
    public class ViewListCustomerHandler : IRequestHandler<ViewListCustomer, Pagination<CustomerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewListCustomerHandler> _logger;
        private readonly ICustomerRepository _repo;

        public ViewListCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewListCustomerHandler> logger, ICustomerRepository repo)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repo = repo;
        }
        public async Task<Pagination<CustomerDTO>> Handle(ViewListCustomer request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("View List Customer");
            var customer = await _repo.GetCustomerList(request.Page, request.PageSize, request.Code, request.Name, request.PhoneNumber, request.Type, request.FromDate, request.ToDate, request.TeleSalesId);
            return customer;
        }
    }
}
