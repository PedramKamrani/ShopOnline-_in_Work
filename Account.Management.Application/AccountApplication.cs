using _0_FramWork.Application;
using AccountManagement.Application.Contract.ViewModels;
using System;
using System.Collections.Generic;

namespace Account.Management.Application
{
    public class AccountApplication : IAccountApplication
    {
        public OperationResult Create(CreateAccount command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditAccount command)
        {
            throw new NotImplementedException();
        }

        public EditAccount GetDetaile(long id)
        {
            throw new NotImplementedException();
        }

        public List<AccountViewModel> search(SearchAccount search)
        {
            throw new NotImplementedException();
        }
    }
}
