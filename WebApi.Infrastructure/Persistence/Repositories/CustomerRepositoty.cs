﻿using CleanArchitecture.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Domain.Entites;

namespace WebApi.Infrastructure.Persistence.Repositories
{
    public class CustomerRepositoty(CustomerSupportDatabaseContext context) : GenericRepository<Customers>(context),ICustomerRepository
    {
    }
}