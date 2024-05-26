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

namespace WebApi.Application.Command.JobC
{
    public class UpdateJobPostCommand :IRequest<job_posts>
    {
        public string? Id { get; set; }
        public string? enterprise_id { get; set; }
        public int? career_field_id { get; set; }
        public string? career_id { get; set; }
        public string? title { get; set; }
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
        public int? approve_status_id { get; set; }
        public string? reason_of_view { get; set; }
        public int? total_view { get; set; }
        public int? total_cv { get; set; }

        public DateTime? deleted_at { get; set; }

        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }

        public string? update_by { get; set; }
    }
    public class UpdateJobPostCommandHandler : IRequestHandler<UpdateJobPostCommand, job_posts>
    {
        private readonly ICustomRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateJobPostCommandHandler> _logger;

        public UpdateJobPostCommandHandler(ICustomRepository repo, IMapper mapper, ILogger<UpdateJobPostCommandHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<job_posts> Handle(UpdateJobPostCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var map = _mapper.Map<job_posts>(request);
            var cus = await _repo.updateV2(map);

            return map;
        }
    }
}
