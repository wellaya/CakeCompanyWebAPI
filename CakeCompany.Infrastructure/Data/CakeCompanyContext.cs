using CakeCompany.Core.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Infrastructure.Data
{
    public class CakeCompanyContext: IdentityDbContext<AppUser>
    {
        public CakeCompanyContext(DbContextOptions<CakeCompanyContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CakeOrder> CakeOrders { get; set; }

        public DbSet<Topping> Toppings { get; set; }
    }
}
