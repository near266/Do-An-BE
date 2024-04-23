using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;
using WebApi.Domain.Entites;

namespace WebApi.Application.Command
{
    public class UpdateCustomerCommand : IRequest<CustomerDTO>
    {
        public CustomerDTO? Customer { get; set; }
    }
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<CustomerDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateComand");
            var cus = await _unitOfWork.CustomerRepository.FirstOrDefaultAsync(x => x.Id == request.Customer.Id);
            var map = _mapper.Map(request.Customer, cus);
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.CustomerRepository.Update(map), cancellationToken);
            return request.Customer;
        }
    }
}
