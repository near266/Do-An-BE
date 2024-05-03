using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entites;
using WebApi.Domain.Entites.Assesment;
using WebApi.Domain.Entites.Job;

namespace WebApi.Domain.Abstractions
{
    public interface ICustomerSupportDbContext
    {
       
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Assessment> assessments { get; set; }
        public DbSet<assessment_questions> assessment_Questions  { get; set; }
        public DbSet<assessment_test_results> Assessment_Test_Results  { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<job_posts> job_Posts { get; set; }
        public DbSet<job_post_candidates> job_post_candidates { get; set; }







        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
