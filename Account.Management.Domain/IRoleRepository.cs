using _0_FramWork.Application;
using Account.Management.Application.Contract.ViewModels;
using System.Collections.Generic;

namespace Account.Management.Domain
{
    public interface IRoleRepository: IBaseRepository<long,Role>
    {
        EditRole GetDetail(long id);
        List<RoleViewModel> GetAllRole();
    }
}
