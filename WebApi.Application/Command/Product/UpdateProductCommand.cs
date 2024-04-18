using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;

namespace WebApi.Application.Command.Product
{
    public class UpdateProductCommand : IRequest<ProductDTO>
    {
        public ProductDTO ProductDto { get; set; } 
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update Command");
            var rq = await _unitOfWork.ProductRepository.FirstOrDefaultAsync(x => x.id == request.ProductDto.id);
            var map = _mapper.Map(request.ProductDto, rq);
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.ProductRepository.Update(map), cancellationToken);
            return request.ProductDto;
        }
    }
}
