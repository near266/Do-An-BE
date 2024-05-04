using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos.Userinfo;

namespace WebApi.Application.Queries.UserInfoQ
{
    public class ViewDetailUserInfoQuery : IRequest<UserInfoDTO>
    {
        public string? id {  get; set; }
    }
    public class ViewDetailUserInfoQueryHandler : IRequestHandler<ViewDetailUserInfoQuery, UserInfoDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewDetailUserInfoQueryHandler> _logger;

        public ViewDetailUserInfoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewDetailUserInfoQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<UserInfoDTO> Handle(ViewDetailUserInfoQuery request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.userInfoRepository.FirstOrDefaultAsync(x => x.Account_id== request.id);
            var result = _mapper.Map<UserInfoDTO>(cus);
            return result;
        }
    }
}
