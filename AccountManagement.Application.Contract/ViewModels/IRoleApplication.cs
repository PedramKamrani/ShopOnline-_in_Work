using _0_FramWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Management.Application.Contract.ViewModels
{
    public interface IRoleApplication
    {
        OperationResult CreatRole(CreateRole command);
        OperationResult EditRole(EditRole command);
        List<RoleViewModel> GetRoles();
        EditRole GetDetail(long id);
    }
}
