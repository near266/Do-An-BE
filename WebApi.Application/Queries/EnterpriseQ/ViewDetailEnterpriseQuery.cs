using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Application.Queries.UserInfoQ;

namespace WebApi.Application.Queries.EnterpriseQ
{
    public class ViewDetailEnterpriseQuery : IRequest<EnterpriseDTO>
    {
        public string? id {  get; set; }
    }
    public class ViewDetailEnterpriseQueryHandler : IRequestHandler<ViewDetailEnterpriseQuery, EnterpriseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewDetailEnterpriseQueryHandler> _logger;

        public ViewDetailEnterpriseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewDetailEnterpriseQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<EnterpriseDTO> Handle(ViewDetailEnterpriseQuery request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.enterpriseRepository.FirstOrDefaultAsync(x => x.account_id == request.id);
            var result = _mapper.Map<EnterpriseDTO>(cus);
            return result;
        }
    }
}
