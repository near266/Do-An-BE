using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Entites;
using WebApi.Domain.Entites.Assesment;
using WebApi.Domain.Entites.Job;

namespace WebApi.Infrastructure.Persistence
{
    public class CustomerSupportDatabaseContext : DbContext, ICustomerSupportDbContext
    {
        public CustomerSupportDatabaseContext(DbContextOptions<CustomerSupportDatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Assessment> assessments { get; set; }
        public DbSet<assessment_questions> assessment_Questions { get; set; }
        public DbSet<assessment_test_results> Assessment_Test_Results { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<job_posts> job_Posts { get; set; }
        public DbSet<job_post_candidates> job_post_candidates { get; set; }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
