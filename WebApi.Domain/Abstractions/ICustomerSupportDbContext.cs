using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entites;

namespace WebApi.Domain.Abstractions
{
    public interface ICustomerSupportDbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Customer_TeleSales> Customers_TeleSales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TeleSales> teleSales { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<recordSheet> recordSheets { get; set; }
        public DbSet<record_Relation> record_Relations { get; set; }


        public DbSet<Product_Category> Products_Categories { get; set;}
    }
}
