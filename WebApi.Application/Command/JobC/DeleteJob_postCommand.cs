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

namespace WebApi.Application.Command.JobC
{
    public class DeleteJob_postCommand :IRequest<int>
    {
        public string? id { get; set; } 
    }
    public class DeleteJob_postCommandHandler : IRequestHandler<DeleteJob_postCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteJob_postCommandHandler> _logger;

        public DeleteJob_postCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteJob_postCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> Handle(DeleteJob_postCommand request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.jobPostRepository.FirstOrDefaultAsync(x => x.Id == request.id);
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.jobPostRepository.Delete(cus), cancellationToken);

            return 1;
        }
    }
}
