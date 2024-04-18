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

namespace WebApi.Application.Command.Product
{
    public class DeleteProductCommand : IRequest<int>
    {
        public Guid? id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.ProductRepository.FirstOrDefaultAsync(x => x.id == request.id);
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.ProductRepository.Delete(cus), cancellationToken);

            return 1;
        }
    }
}
