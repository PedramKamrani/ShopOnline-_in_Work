using Account.Management.Infrastracure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Account.Management.Infrastracure
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options):base(options)
        {

        }

        public DbSet<Account.Management.Domain.Users.Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assmberly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assmberly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
