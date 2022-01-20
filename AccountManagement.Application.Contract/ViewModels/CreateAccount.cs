namespace AccountManagement.Application.Contract.ViewModels
{
    public class CreateAccount
    {
        public string Fullname { get;  set; }
        public string UserName { get;  set; }
        public string Password { get;  set; }
        public string Mobile { get;  set; }
        public long RoleId { get;  set; }
        public string ProfilePhoto { get;  set; }

    }
}
