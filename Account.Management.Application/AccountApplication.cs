using _0_FrameWork.Application;
using _0_FramWork.Application;
using Account.Management.Domain;
using Account.Management.Infrastracure.Repository;
using AccountManagement.Application.Contract.ViewModels;
using System;
using System.Collections.Generic;

namespace Account.Management.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _repository;
        private readonly IAuthHelper _auther;
        private readonly IPasswordHasher _passwordHasher ;
        private readonly IFileUploader _uploader;
        public AccountApplication(IAccountRepository repository, IAuthHelper auther, IPasswordHasher passwordHasher, IFileUploader uploader)
        {
            _repository= repository;  
            _auther= auther;
            _passwordHasher= passwordHasher;
            _uploader= uploader;
        }
        public OperationResult Create(CreateAccount command)
        {
            OperationResult operation= new OperationResult();
            if(_repository.Exsists(x=>x.UserName==command.UserName))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var password=_passwordHasher.Hash(command.Password.ToString());
            var picture = _uploader.Upload(command.ProfilePhoto, "ProfilePhotos");
            var model = new Accounts(command.Fullname,command.UserName,
               password,command.Mobile,command.RoleId,picture);
            _repository.Create(model);
            _repository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditAccount command)
        {
            OperationResult operation = new OperationResult();
            
            var accunt=_repository.Get(command.Id);
            if(accunt==null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if (_repository.Exsists(x => x.UserName == command.UserName && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var password = _passwordHasher.Hash(command.Password);
            var picture = _uploader.Upload(command.ProfilePhoto, "ProfilePhotos");
             accunt.Edit(command.Fullname,command.UserName,password,command.Mobile,command.RoleId,picture);
            _repository.SaveChanges();
            return operation.Success();
        }

        public EditAccount GetDetaile(long id)
        {
           return _repository.GetDetail(id);
        }

        public OperationResult Login(LoginViewModels models)
        {
            OperationResult operation=new OperationResult();
            var account=_repository.GetBy(models.Username);
            if (account == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if (account == null || models.Password == null)
                return operation.Failed(ApplicationMessage.WrongUserPass);

            var result = _passwordHasher.Check(account.Password, models.Password);
            if(!result.Verified)
                return operation.Failed(ApplicationMessage.WrongUserPass);

            var Auther=new LoginViewModels(account.id,account.RoleId,account.UserName,account.Fullname,account.Mobile,null);
            _auther.Signin(Auther);
            return operation.Success();
        }

        public void LogOut()
        {
            _auther.SignOut();
        }

        public List<AccountViewModel> search(SearchAccount search)
        {
            return  _repository.serach(search);
        }
    }
}
