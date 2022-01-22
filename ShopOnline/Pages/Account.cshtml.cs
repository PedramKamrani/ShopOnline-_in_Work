using Account.Management.Application.Contract.ViewModels;
using AccountManagement.Application.Contract.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountApplication _account;
        private readonly IRoleApplication _role;
        public SelectList Rolelist { get; set; } 
        public CreateAccount Create { get; set; }
        public AccountModel(IAccountApplication account, IRoleApplication role)
        {
            _account = account;
            _role = role;
        }
        public void OnGet()
        {
            Rolelist = new SelectList(_role.GetRoles(), "Id", "Name");
        }
        public IActionResult OnPost(CreateAccount command)
        {
            _account.Create(command);
            return Page();
        }
    }
}
