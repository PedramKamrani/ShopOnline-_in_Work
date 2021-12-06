using DisCount.Manangment.Domain.CustomerDiscounts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Discount.Managment.Infrastrucer.EFCore
{
    public class CustomerDisCountContext:DbContext
    {
        public CustomerDisCountContext(DbContextOptions<CustomerDisCountContext> options):base(options)
        {

        }
       public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
