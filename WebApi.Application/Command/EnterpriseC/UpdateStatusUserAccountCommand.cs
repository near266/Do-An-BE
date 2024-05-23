using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites.Account;

namespace WebApi.Application.Command.EnterpriseC
{
    public class UpdateStatusUserAccountCommand : IRequest<userInfo>
    {
        public string? account_id { get; set; }
        public int? status { get; set; }
    }
    public class UpdateStatusUserAccountCommandHandler : IRequestHandler<UpdateStatusUserAccountCommand, userInfo>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStatusUserAccountCommandHandler> _logger;

        public UpdateStatusUserAccountCommandHandler(ICustomRepository repo, IMapper mapper, ILogger<UpdateStatusUserAccountCommandHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<userInfo> Handle(UpdateStatusUserAccountCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var cus = await _repo.UpdateStatusInfo(request.account_id, request.status);

            return cus;
        }
    }
}
