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
        public int page { get; set; }
        public int pageSize { get; set; }
    }
    public class ViewListCustomerHandler : IRequestHandler<ViewListCustomer, Pagination<CustomerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewListCustomerHandler> _logger;

        public ViewListCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewListCustomerHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Pagination<CustomerDTO>> Handle(ViewListCustomer request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("View List Customer");
            var cus = await _unitOfWork.CustomerRepository.ToPagination(request.page,request.pageSize);
            var map = _mapper.Map<Pagination<CustomerDTO>>(cus);
            return map;
        }
    }
}
