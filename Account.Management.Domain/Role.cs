using _0_FramWork.BaseClass;
using System.Collections.Generic;

namespace Account.Management.Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; }

        public List<Accounts> Accounts { get; private set; }
    }
}
