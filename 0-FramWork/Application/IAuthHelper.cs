using System.Collections.Generic;

namespace _0_FrameWork.Application
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void Signin(LoginViewModels account);
        string CurrentAccountRole();
        LoginViewModels CurrentAccountInfo();
        List<int> GetPermissions();
        long CurrentAccountId();
        string CurrentAccountMobile();
    }
}
