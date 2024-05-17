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

namespace WebApi.Application.Command.EnterpriseC
{
    public class UpdateEnterpriseCommand:IRequest<EnterpriseDTO>
    {
        public EnterpriseDTO? EnterpriseDTO { get; set; }

    }
    public class UpdateEnterpriseCommandHandler : IRequestHandler<UpdateEnterpriseCommand, EnterpriseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEnterpriseCommandHandler> _logger;

        public UpdateEnterpriseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateEnterpriseCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<EnterpriseDTO> Handle(UpdateEnterpriseCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var cus = await _unitOfWork.enterpriseRepository.FirstOrDefaultAsync(x => x.Id == request.EnterpriseDTO.Id);

            var map = _mapper.Map(request.EnterpriseDTO, cus);
  

            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.enterpriseRepository.Update(map), cancellationToken);
            return request.EnterpriseDTO;
        }

    }
}
