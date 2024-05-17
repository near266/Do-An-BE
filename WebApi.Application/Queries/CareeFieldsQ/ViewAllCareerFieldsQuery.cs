using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Application.Models;
using WebApi.Application.Queries.UserInfoQ;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Queries.CareeFieldsQ
{
    public class ViewAllCareerFieldsQuery : IRequest<Pagination<career_fields>>
    {
        public int page { get; set; }
        public int pageSize { get; set; }
    }
    public class ViewAllCareerFieldsQueryHandler : IRequestHandler<ViewAllCareerFieldsQuery, Pagination<career_fields>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ViewAllCareerFieldsQueryHandler> _logger;

        public ViewAllCareerFieldsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ViewAllCareerFieldsQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Pagination<career_fields>> Handle(ViewAllCareerFieldsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("View List Customer");
            var cus = await _unitOfWork.CareerFieldRepository.ToPagination(request.page, request.pageSize);
            
            return cus;
        }
    }
}
