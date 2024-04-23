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
using WebApi.Application.Queries.Product;

namespace WebApi.Application.Queries.TeleSale
{
    public class ViewDetailTeleSaleQuery : IRequest<TeleSaleDTO>
    {
        public Guid? id { get; set; }
    }
    public class ViewDetailTeleSaleQueryHandler : IRequestHandler<ViewDetailTeleSaleQuery, TeleSaleDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewDetailTeleSaleQueryHandler> _logger;

        public ViewDetailTeleSaleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewDetailTeleSaleQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<TeleSaleDTO> Handle(ViewDetailTeleSaleQuery request, CancellationToken cancellationToken)
        {

            var rq = await _unitOfWork.TeleSalesRepository.FirstOrDefaultAsync(x => x.Id == request.id);
            var result = _mapper.Map<TeleSaleDTO>(rq);
            return result;
        }
    }
}
