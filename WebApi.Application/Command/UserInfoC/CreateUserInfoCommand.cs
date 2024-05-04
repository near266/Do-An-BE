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
    public class CreateUserInfoCommand : IRequest<UserInfoDTO>
    {
        public UserInfoDTO? user { get; set; }
    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateUserInfoCommand, UserInfoDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCustomerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<UserInfoDTO> Handle(CreateUserInfoCommand request, CancellationToken cancellationToken)
        {
      
            var map = _mapper.Map<userInfo>(request.user);
           
            
         await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.userInfoRepository.AddAsync(map), cancellationToken);

            return request.user;
        }
    }
}