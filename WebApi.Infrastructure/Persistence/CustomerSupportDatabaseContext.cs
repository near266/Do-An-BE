using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Entites;

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


        public DbSet<Customers> Customers { get; set; }
        public DbSet<Customer_TeleSales> Customers_TeleSales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TeleSales> TeleSales { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product_Category> Products_Categories { get; set; }
        public DbSet<RecordSheet> RecordSheets { get; set; }
        public DbSet<Record_Relation> Record_Relations { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
