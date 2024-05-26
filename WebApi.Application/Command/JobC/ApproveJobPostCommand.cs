using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Queries.EnterpriseQ;
using WebApi.Domain.Entites.Account;
using WebApi.Shared.Constants;

namespace WebApi.Application.Command.JobC
{
    public class ApproveJobPostCommand : IRequest<int>
    {
        public string id { get; set; }
        public int type { get; set; }
    }
    public class ApproveJobPostCommandHandler : IRequestHandler<ApproveJobPostCommand, int>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<ApproveJobPostCommandHandler> _logger;

        public ApproveJobPostCommandHandler(ICustomRepository repo, IMapper mapper, ILogger<ApproveJobPostCommandHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> Handle(ApproveJobPostCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var cus = await _repo.ApprovePost(request.id, request.type);

            return cus;
        }
    }
}
