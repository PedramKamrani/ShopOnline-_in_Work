using Account.Management.Domain;
using Account.Management.Infrastracure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Account.Management.Infrastracure
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options):base(options)
        {

        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Assmbely = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(Assmbely);
        }
    }
}
