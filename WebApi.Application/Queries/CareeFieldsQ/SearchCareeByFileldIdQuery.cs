using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models;
using WebApi.Application.Queries.Job_postQ;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Queries.CareeFieldsQ
{
    public class SearchCareeByFileldIdQuery:IRequest<Pagination<career>>
    {
        public int? idField { get; set; }   
        public int page {  get; set; }
        public int pageSize { get; set; }
    }
    public class SearchCareeByFileldIdQueryHandler : IRequestHandler<SearchCareeByFileldIdQuery, Pagination<career>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SearchCareeByFileldIdQueryHandler> _logger;

        public SearchCareeByFileldIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SearchCareeByFileldIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Pagination<career>> Handle(SearchCareeByFileldIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("View List Customer");
            var res = new Pagination<career>();

            var cus = await _unitOfWork.careeRepository.GetAsync(i => i.field_id == request.idField, request.page, request.pageSize);

            return cus;
        }
    }
}

