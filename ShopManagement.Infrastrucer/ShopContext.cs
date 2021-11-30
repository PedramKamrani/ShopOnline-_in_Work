using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastrucer.Mapping;
using System;

namespace ShopManagement.Infrastrucer
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
                
        }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            var Assmbely = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(Assmbely);
        }
    }
}
