using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Command.UserInfoC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Domain.Entites.Account;

namespace WebApi.Application.Command.EnterpriseC
{
    public class CreateEnterpriseCommand:IRequest<EnterpriseDTO>
    {
        public EnterpriseDTO? EnterpriseDTO { get; set; }
    }
    public class CreateEnterpriseCommandHandler : IRequestHandler<CreateEnterpriseCommand, EnterpriseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEnterpriseCommandHandler> _logger;

        public CreateEnterpriseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateEnterpriseCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<EnterpriseDTO> Handle(CreateEnterpriseCommand request, CancellationToken cancellationToken)
        {

            var map = _mapper.Map<enterprises>(request.EnterpriseDTO);


            await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.enterpriseRepository.AddAsync(map), cancellationToken);

            return request.EnterpriseDTO;
        }
    }
}
