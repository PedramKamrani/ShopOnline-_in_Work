using AccountManagement.Application.Contract.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountApplication _account;
        public CreateAccount Create { get; set; }
        public AccountModel(IAccountApplication account)
        {
            _account = account;
        }
        public void OnGet()
        {
            //ViewData["Rolelist"]=
        }
        public IActionResult OnPost(CreateAccount command)
        {
            _account.Create(command);
            return Page();
        }
    }
}
