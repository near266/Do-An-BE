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
using WebApi.Domain.Entites.Account;

namespace WebApi.Application.Command.UserInfoC
{
    public class UpdateUserInfoCommand :IRequest<UserInfoDTO>
    {
        public UserInfoDTO? userInfo { get; set; }
    }
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand, UserInfoDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserInfoCommandHandler> _logger;

        public UpdateUserInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateUserInfoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<UserInfoDTO> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var cus = await _unitOfWork.userInfoRepository.FirstOrDefaultAsync(x => x.Id == request.userInfo.Id);
            
            var map = _mapper.Map(request.userInfo, cus);
            
            
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.userInfoRepository.Update(map), cancellationToken);
            return request.userInfo;
        }
    }
}
