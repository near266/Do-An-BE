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
        public DbSet<Customer_TeleSales> Customers_TeleSales { get ; set ; }
        public DbSet<Product> Products { get ; set; }
        public DbSet<TeleSales> teleSales { get; set; }

        public DbSet<Category> Categories { get ; set ; }
        public DbSet<Product_Category> Products_Categories { get; set; }
        public DbSet<recordSheet> recordSheets { get; set ; }
        public DbSet<record_Relation> record_Relations { get ; set ; }
    }
}
