using Account.Management.Application;
using Account.Management.Application.Contract.ViewModels;
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

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleApplication, RoleApplication>();
            services.AddDbContext<AccountContext>(op =>
            {
                op.UseSqlServer(connectionstring);
            });
        }
    }
}
