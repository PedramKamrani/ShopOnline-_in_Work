using _0_FramWork.Application;
using Account.Management.Application.Contract.ViewModels;
using Account.Management.Domain;
using System;
using System.Collections.Generic;

namespace Account.Management.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _repository;
        public RoleApplication(IRoleRepository repository)
        {
            _repository = repository;
        }
        public OperationResult CreatRole(CreateRole command)
        {
            OperationResult operation = new OperationResult();
            if (_repository.Exsists(x => x.Name == command.Name))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var model=new Role(command.Name);
            _repository.Create(model);
            _repository.SaveChanges();
            return operation.Success();
        }

        public OperationResult EditRole(EditRole command)
        {
            OperationResult operation=new OperationResult();
            var role=_repository.Get(command.Id);
            if (_repository.Exsists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            role.Edit(command.Name);
            _repository.SaveChanges();
            return operation.Success();
        }

        public EditRole GetDetail(long id)
        {
           return _repository.GetDetail(id);
        }

        public List<RoleViewModel> GetRoles()
        {
           return _repository.GetAllRole();   
        }
    }
}
