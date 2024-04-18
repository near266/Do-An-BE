using Amazon.Runtime.Internal;
using CleanArchitecture.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites;

namespace WebApi.Infrastructure.Persistence.Repositories
{
    public class ProductRepository(CustomerSupportDatabaseContext context) : GenericRepository<Product>(context) ,IProductRepository
    {
    }
}
