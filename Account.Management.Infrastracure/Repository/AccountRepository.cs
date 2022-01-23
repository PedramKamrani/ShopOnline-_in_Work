using _0_FramWork.BaseClass;
using Account.Management.Domain;
using AccountManagement.Application.Contract.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Account.Management.Infrastracure.Repository
{
    public class AccountRepository : BaseRepository<long,Accounts>, IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public AccountViewModel GetBy(string username)
        {
            return _context.Accounts.Where(x=>x.UserName == username)
                .Select(x=>new AccountViewModel
                {
                    UserName = x.UserName,
                    Fullname = x.Fullname,
                    id = x.Id,
                    Mobile=x.Mobile,
                    ProfilePhoto=x.ProfilePhoto,
                    Password=x.Password,
                    RoleId=x.RoleId
                    
                }).FirstOrDefault();
        }

        public EditAccount GetDetail(long id)
        {
            var account = _context.Accounts.Select(x => new EditAccount
            {
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                UserName = x.UserName,
                RoleId = x.RoleId,
            }).FirstOrDefault(x => x.Id == id);
            return account;

        }

        public List<AccountViewModel> serach(SearchAccount search)
        {
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                id = x.Id,
                UserName = x.UserName,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = "مدیریت"
            });
            if (search != null)
                query = query.Where(x => EF.Functions.Like(x.Fullname, $"%{search.Fullname}%"));
            if (search != null)
                query = query.Where(x => EF.Functions.Like(x.UserName, $"%{search.UserName}%"));
            if (search != null)
                query = query.Where(x => EF.Functions.Like(x.Mobile, $"%{search.Mobile}%"));
            return query.OrderBy(x => x.id).ToList();
        }
    }
}
