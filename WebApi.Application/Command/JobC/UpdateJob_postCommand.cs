using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Command.UserInfoC;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Domain.Entites.Job;

namespace WebApi.Application.Command.JobC
{
    public class UpdateJob_postCommand : IRequest<job_posts>
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
        public string? approve_status_id { get; set; }
        public string? reason_of_view { get; set; }
        public int? total_view { get; set; }
        public int? total_cv { get; set; }

        public DateTime? deleted_at { get; set; }

        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }

        public string? update_by { get; set; }
    }
    public class UpdateJob_postCommandHandler : IRequestHandler<UpdateJob_postCommand, job_posts>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateJob_postCommandHandler> _logger;

        public UpdateJob_postCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateJob_postCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<job_posts> Handle(UpdateJob_postCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("UpdateComand");
            var cus = await _unitOfWork.jobPostRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            var map = _mapper.Map(request, cus);
           
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.jobPostRepository.Update(map), cancellationToken);
            return map;
        }
    }
}
