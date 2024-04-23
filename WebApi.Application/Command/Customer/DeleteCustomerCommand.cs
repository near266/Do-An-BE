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

namespace WebApi.Application.Command.Customer
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        public Guid? Id { get; set; }
    }
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.CustomerRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.CustomerRepository.Delete(cus), cancellationToken);

            return 1;
        }
    }
}
