using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Queries.CareeFieldsQ
{
    public class ViewDetailCareeQuery : IRequest<career>
    {
        public string? id {  get; set; }    
    }
    public class ViewDetailCareeQueryHandler : IRequestHandler<ViewDetailCareeQuery, career>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewDetailCareeQueryHandler> _logger;

        public ViewDetailCareeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewDetailCareeQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<career> Handle(ViewDetailCareeQuery request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.careeRepository.FirstOrDefaultAsync(x => x.id == request.id);
          ;
            return cus;
        }
    }
}
