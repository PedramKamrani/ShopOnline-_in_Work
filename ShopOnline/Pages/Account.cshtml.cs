using Account.Management.Application.Contract.ViewModels;
using AccountManagement.Application.Contract.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountApplication _account;
        private readonly IRoleApplication _role;
        public List<RoleViewModel> Rolelist { get; set; }

        public CreateAccount Create;
        public AccountModel(IAccountApplication account, IRoleApplication role)
        {
            _account = account;
            _role = role;
        }
        public void OnGet()
        {
            Rolelist = _role.GetRoles();
            
        }
        public IActionResult OnPost(CreateAccount command)
        {
            _account.Create(command);
            Rolelist = _role.GetRoles();
            return Page();
        }
    }
}
