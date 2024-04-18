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
using WebApi.Application.Queries.Customer;

namespace WebApi.Application.Queries.Product
{
    public class ViewDetailProductQuery : IRequest<ProductDTO>
    {
        public Guid? id { get; set; }
    }
    public class ViewDetailProductQueryHandler : IRequestHandler<ViewDetailProductQuery, ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewDetailProductQueryHandler> _logger;

        public ViewDetailProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewDetailProductQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ProductDTO> Handle(ViewDetailProductQuery request, CancellationToken cancellationToken)
        {

            var rq = await _unitOfWork.ProductRepository.FirstOrDefaultAsync(x => x.id == request.id);
            var result = _mapper.Map<ProductDTO>(rq);
            return result;
        }
    }
}
