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
using WebApi.Domain.Entites;

namespace WebApi.Application.Command.TeleSale
{
    public class CreateTeleSaleCommand : IRequest<TeleSaleDTO>
    {
        public TeleSaleDTO? teleSaleDTO { get; set; }   

    }
    public class CreateTeleSaleCommandHandler : IRequestHandler<CreateTeleSaleCommand, TeleSaleDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTeleSaleCommandHandler> _logger;

        public CreateTeleSaleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateTeleSaleCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<TeleSaleDTO> Handle(CreateTeleSaleCommand request, CancellationToken cancellationToken)
        {

            var map = _mapper.Map<TeleSales>(request.teleSaleDTO);
            await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.teleSalesRepository.AddAsync(map), cancellationToken);
            return request.teleSaleDTO;
        }
    }
}
