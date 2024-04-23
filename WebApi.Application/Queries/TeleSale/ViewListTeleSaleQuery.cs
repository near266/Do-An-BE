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
using WebApi.Application.Queries.Product;

namespace WebApi.Application.Queries.TeleSale
{
    public class ViewListTeleSaleQuery : IRequest<Pagination<TeleSaleDTO>>
    {
        public int page { get; set; }
        public int pageSize { get; set; }
    }
    public class ViewListTeleSaleQueryHandler : IRequestHandler<ViewListTeleSaleQuery, Pagination<TeleSaleDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewListTeleSaleQueryHandler> _logger;

        public ViewListTeleSaleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewListTeleSaleQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Pagination<TeleSaleDTO>> Handle(ViewListTeleSaleQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("View List Sale");
            var cus = await _unitOfWork.TeleSalesRepository.ToPagination(request.page, request.pageSize);
            var map = _mapper.Map<Pagination<TeleSaleDTO>>(cus);
            return map;
        }
    }
}
