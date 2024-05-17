using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Queries.EnterpriseQ;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Queries.CareeFieldsQ
{
    public class ViewDetailFieldsQuery : IRequest<career_fields>
    {
        public int? id { get; set; }
    }
    public class ViewDetailFieldsQueryHandler : IRequestHandler<ViewDetailFieldsQuery, career_fields>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewDetailFieldsQueryHandler> _logger;

        public ViewDetailFieldsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewDetailFieldsQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<career_fields> Handle(ViewDetailFieldsQuery request, CancellationToken cancellationToken)
        {

            var cus = await _unitOfWork.CareerFieldRepository.FirstOrDefaultAsync(x => x.id == request.id);
            var result = _mapper.Map<career_fields>(cus);
            return result;
        }
    }
}
