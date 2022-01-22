using Account.Management.Application;
using Account.Management.Domain;
using Account.Management.Infrastracure;
using Account.Management.Infrastracure.Repository;
using AccountManagement.Application.Contract.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Management.Configure
{
    public static class BootstraperMappingAccountConfigure
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<IAccountApplication, AccountApplication>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddDbContext<AccountContext>(op =>
            {
                op.UseSqlServer(connectionstring);
            });
        }
    }
}
