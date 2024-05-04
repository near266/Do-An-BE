using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;

namespace WebApi.Application.Command.UserInfoC
{
    public class DeleteUserInfoCommand : IRequest<int>
    {
        public string? id {  get; set; }
    }
    public class DeleteUserInfoCommandHandler : IRequestHandler<DeleteUserInfoCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserInfoCommandHandler> _logger;

        public DeleteUserInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteUserInfoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> Handle(DeleteUserInfoCommand request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.userInfoRepository.FirstOrDefaultAsync(x => x.Id == request.id);
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.userInfoRepository.Delete(cus), cancellationToken);

            return 1;
        }
    }
}
