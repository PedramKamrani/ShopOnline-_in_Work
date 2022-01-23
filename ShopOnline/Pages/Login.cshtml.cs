using _0_FrameWork.Application;
using Account.Management.Application.Contract.ViewModels;
using AccountManagement.Application.Contract.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountApplication _account;
        public LoginModel(IAccountApplication account)
        {
            _account = account;
        }
        public LoginViewModels Login { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(LoginViewModels login)
        {
            _account.Login(login);

            return Page();

        }

        public IActionResult OnPostLogout()
        {
            _account.LogOut();

            return Page();

        }

    }
}
