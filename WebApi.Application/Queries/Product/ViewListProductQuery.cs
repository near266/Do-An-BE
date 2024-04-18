using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Models.Dtos;
using WebApi.Application.Queries.Customer;

namespace WebApi.Application.Queries.Product
{
    public class ViewListProductQuery : IRequest<Pagination<ProductDTO>>
    {
        public int page { get; set; }
        public int pageSize { get; set; }
    }
    public class ViewListProductQueryHandler : IRequestHandler<ViewListProductQuery, Pagination<ProductDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewListProductQueryHandler> _logger;

        public ViewListProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewListProductQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Pagination<ProductDTO>> Handle(ViewListProductQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("View List Customer");
            var cus = await _unitOfWork.ProductRepository.ToPagination(request.page, request.pageSize);
            var map = _mapper.Map<Pagination<ProductDTO>>(cus);
            return map;
        }
    }
}
