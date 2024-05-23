using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Command.JobC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites.Account;
using WebApi.Domain.Entites.Job;
using WebApi.Shared.Constants;

namespace WebApi.Application.Command.EnterpriseC
{
    public class UpdateStatusEnterpriseCommand : IRequest<enterprises>
    {
        public string? account_id { get; set; }
        public int? status { get; set; }
    }
    public class UpdateStatusEnterpriseCommandHandler : IRequestHandler<UpdateStatusEnterpriseCommand, enterprises>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStatusEnterpriseCommandHandler> _logger;

        public UpdateStatusEnterpriseCommandHandler(ICustomRepository repo, IMapper mapper, ILogger<UpdateStatusEnterpriseCommandHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<enterprises> Handle(UpdateStatusEnterpriseCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var cus = await _repo.UpdatestatusEnterprise(request.account_id,request.status);

            return cus;
        }
    }
}
