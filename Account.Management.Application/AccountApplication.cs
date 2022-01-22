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
        private readonly IPasswordHasher _passwordHasher ;
        private readonly IFileUploader _uploader;
        public AccountApplication(AccountRepository repository, IPasswordHasher passwordHasher, IFileUploader uploader)
        {
            _repository= repository;    
            _passwordHasher= passwordHasher;
            _uploader= uploader;
        }
        public OperationResult Create(CreateAccount command)
        {
            OperationResult operation= new OperationResult();
            if(_repository.Exsists(x=>x.UserName==command.UserName))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var password=_passwordHasher.Hash(command.Password);
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
                return operation.Faild(ApplicationMessage.RecordNotFound);
            if (_repository.Exsists(x => x.UserName == command.UserName && x.Id != command.Id))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
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

        public List<AccountViewModel> search(SearchAccount search)
        {
            return  _repository.serach(search);
        }
    }
}
