using Microsoft.EntityFrameworkCore;

namespace Colleague.Managment.Infrastucre.EFCore
{
    public class ColleagueContext : DbContext
    {
        public ColleagueContext(DbContextOptions<ColleagueContext> options) : base(options)
        {

        }
        //public DbSet<> Colleagues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
