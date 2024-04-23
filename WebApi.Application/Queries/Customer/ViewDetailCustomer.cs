using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Command.Customer;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;

namespace WebApi.Application.Queries.Customer
{
    public class ViewDetailCustomer : IRequest<CustomerDTO>
    {
        public string? Id { get; set; }
    }
    public class ViewDetailCustomerHandler : IRequestHandler<ViewDetailCustomer, CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewDetailCustomerHandler> _logger;

        public ViewDetailCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewDetailCustomerHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<CustomerDTO> Handle(ViewDetailCustomer request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.CustomerRepository.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);
            var result = _mapper.Map<CustomerDTO>(cus);
            return result;
        }
    }
}
