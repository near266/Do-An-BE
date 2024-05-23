using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Queries.Job_postQ;
using WebApi.Domain.Entites.Account;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Queries.EnterpriseQ
{
    public class ViewEnterrpiseByIdQuery : IRequest<enterprises>
    {
        public string? id { get; set; }
    }
    public class ViewEnterrpiseByIdQueryHandler : IRequestHandler<ViewEnterrpiseByIdQuery, enterprises>
    {
        private readonly ICustomRepository _Repo;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewEnterrpiseByIdQueryHandler> _logger;

        public ViewEnterrpiseByIdQueryHandler(ICustomRepository Repo, IMapper mapper, ILogger<ViewEnterrpiseByIdQueryHandler> logger)
        {
            _Repo = Repo ?? throw new ArgumentNullException(nameof(Repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<enterprises> Handle(ViewEnterrpiseByIdQuery request, CancellationToken cancellationToken)
        {



            var map= await _Repo.getEnterpriseById(request.id);

            return map;
        }
    }
}
