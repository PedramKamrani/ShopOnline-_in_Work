using _0_FramWork.BaseClass;
using Account.Management.Application.Contract.ViewModels;
using Account.Management.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Account.Management.Infrastracure.Repository
{
    public class RoleRepository : BaseRepository<long, Role>, IRoleRepository
    {
        private readonly AccountContext _context;
        public RoleRepository(AccountContext context) : base(context)
        {

        }

        public EditRole GetDetail(long id)
        {
            var role = _context.Roles.Select(x=>new EditRole
            {
                Id = x.Id,
                Name=x.Name
            }).FirstOrDefault(x=>x.Id==id);
            return role;
           
   
        }

        public List<RoleViewModel> GetAllRole()
        
        {
           var roles= _context.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
            });
            return roles.ToList();
        }
    }
}
