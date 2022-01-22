using _0_FramWork.Application;
using AccountManagement.Application.Contract.ViewModels;
using System.Collections.Generic;

namespace Account.Management.Domain
{
    public interface IAccountRepository : IBaseRepository<long, Accounts>
    {
        EditAccount GetDetail(long id);
        List<AccountViewModel> serach(SearchAccount search);
    }
}
