using _0_FrameWork.Application;
using _0_FramWork.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.ViewModels
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount command);
        OperationResult Edit(EditAccount command);
        EditAccount GetDetaile(long id);
        List<AccountViewModel> search(SearchAccount search);
        OperationResult Login(LoginViewModels models);
        void LogOut();
    }
}
