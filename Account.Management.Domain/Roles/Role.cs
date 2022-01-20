using _0_FramWork.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Management.Domain.Roles
{
    public class Role:BaseEntity
    {
        public string Name { get; private set; }

        public List<Users.Account> Accounts { get; private set; }
    }
}
