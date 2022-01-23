using _0_FramWork.Application;
using AccountManagement.Application.Contract.ViewModels;
using System.Collections.Generic;

namespace Account.Management.Domain
{
    public interface IAccountRepository : IBaseRepository<long, Accounts>
    {
        EditAccount GetDetail(long id);
        AccountViewModel GetBy(string username);
        List<AccountViewModel> serach(SearchAccount search);
    }
}
