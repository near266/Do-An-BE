using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApi.Application.Command.EnterpriseC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Domain.Entites.Account;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Command.CareerFieldC
{
    public class CreateCareerFieldsCommand : IRequest<career_fields>
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? name { get; set; }
        public int? active { get; set; }
        public string? avatar { get; set; }
    }
    public class CreateCareerFieldsCommandHandler : IRequestHandler<CreateCareerFieldsCommand, career_fields>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCareerFieldsCommandHandler> _logger;

        public CreateCareerFieldsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCareerFieldsCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<career_fields> Handle(CreateCareerFieldsCommand request, CancellationToken cancellationToken)
        {

            var map = _mapper.Map<career_fields>(request);


            await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.CareerFieldRepository.AddAsync(map), cancellationToken);

            return map;
        }
    }
}
