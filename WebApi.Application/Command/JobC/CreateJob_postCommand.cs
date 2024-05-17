using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Command.CareerFieldC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Command.JobC
{
    public class CreateJob_postCommand : IRequest<job_posts>
    {
       
        public string? enterprise_id { get; set; }
        public int? career_field_id { get; set; }
        public string? career_id { get; set; } = "";
        public string? title { get; set; } = "";
        public string? slug { get; set; }
        public string? city { get; set; }
        public string? district { get; set; }
        public string? address { get; set; }
        public string? map_url { get; set; }
        public string? image_url { get; set; }
        public string? form_of_work { get; set; }
        public string? diploma { get; set; }
        public string? experience { get; set; }
        public string? level { get; set; }
        public string? gender { get; set; }
        public DateTime? deadline { get; set; }
        public string? probationary_period { get; set; }
        public string? salary_type { get; set; }
        public int? salary_min { get; set; }
        public int? salary_max { get; set; }
        public string? overview { get; set; }
        public string? requirement { get; set; }
        public string? benefit { get; set; }
        public string? contact_name { get; set; }
        public string? contact_phone { get; set; }
        public string? contact_email { get; set; }
        public string? status_id { get; set; }
        public string? approve_status_id { get; set; }
        public string? reason_of_view { get; set; }
        public int? total_view { get; set; }
        public int? total_cv { get; set; }

        public DateTime? deleted_at { get; set; }
     
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
  
        public string? update_by { get; set; }
        public DateTime? update_at { get; set; }
    }
    public class CreateJob_postCommandHandler : IRequestHandler<CreateJob_postCommand, job_posts>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateJob_postCommandHandler> _logger;

        public CreateJob_postCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateJob_postCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<job_posts> Handle(CreateJob_postCommand request, CancellationToken cancellationToken)
        {

            var map = _mapper.Map<job_posts>(request);


            await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.jobPostRepository.AddAsync(map), cancellationToken);

            return map;
        }
    }

}
