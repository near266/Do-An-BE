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
using WebApi.Application.Models.Dtos.Userinfo;

namespace WebApi.Application.Queries.UserInfoQ
{
    public class ViewAllUserInfoQuery : IRequest<Pagination<UserInfoDTO>>
    {
        public int page { get; set; }
        public int pageSize { get; set; }
    }
    public class ViewAllUserInfoQueryHandler : IRequestHandler<ViewAllUserInfoQuery, Pagination<UserInfoDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewAllUserInfoQueryHandler> _logger;

        public ViewAllUserInfoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewAllUserInfoQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Pagination<UserInfoDTO>> Handle(ViewAllUserInfoQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("View List Customer");
            var cus = await _unitOfWork.userInfoRepository.ToPagination(request.page, request.pageSize);
            var map = _mapper.Map<Pagination<UserInfoDTO>>(cus);
            return map;
        }
    }
}
