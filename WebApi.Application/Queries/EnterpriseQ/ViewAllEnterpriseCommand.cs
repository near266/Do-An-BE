using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Command.EnterpriseC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites.Account;
using WebApi.Shared.Constants;

namespace WebApi.Application.Queries.EnterpriseQ
{
    public class ViewAllEnterpriseCommand :IRequest<PagedList<enterprises>>
    {
        public int status { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }   
    }
    public class ViewAllEnterpriseCommandHandler : IRequestHandler<ViewAllEnterpriseCommand, PagedList<enterprises>>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewAllEnterpriseCommandHandler> _logger;

        public ViewAllEnterpriseCommandHandler(ICustomRepository repo, IMapper mapper, ILogger<ViewAllEnterpriseCommandHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<PagedList<enterprises>> Handle(ViewAllEnterpriseCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var cus = await _repo.ViewListEnterprise(request.status,request.page, request.pageSize);

            return cus;
        }
    }
}
