using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Command.Product;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos;

namespace WebApi.Application.Command.TeleSale
{
    public class UpdateTeleSaleCommand : IRequest<TeleSaleDTO>
    {
        public TeleSaleDTO TeleSaleDTO { get; set; }
    }
    public class UpdateTeleSaleCommandHandler : IRequestHandler<UpdateTeleSaleCommand, TeleSaleDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTeleSaleCommandHandler> _logger;

        public UpdateTeleSaleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateTeleSaleCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<TeleSaleDTO> Handle(UpdateTeleSaleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update Command");
            var rq = await _unitOfWork.TeleSalesRepository.FirstOrDefaultAsync(x => x.Id == request.TeleSaleDTO.Id);
            var map = _mapper.Map(request.TeleSaleDTO, rq);
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.TeleSalesRepository.Update(map), cancellationToken);
            return request.TeleSaleDTO;
        }
    }
}
