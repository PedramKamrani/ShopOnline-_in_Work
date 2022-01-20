using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Management.Infrastracure.Mapping
{
    internal class AccountMapping : IEntityTypeConfiguration<Account.Management.Domain.Users.Account>
    {
        public void Configure(EntityTypeBuilder<Domain.Users.Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x=>x.Fullname).HasMaxLength(128);


            builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleId);
        }
    }
}
