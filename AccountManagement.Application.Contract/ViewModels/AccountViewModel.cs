namespace AccountManagement.Application.Contract.ViewModels
{
    public class AccountViewModel
    {
        public long id { get;  set; }
        public string Fullname { get;  set; }
        public string UserName { get;  set; }
        public string Password { get;  set; }
        public string Mobile { get;  set; }
        public long RoleId { get;  set; }
        public string Role { get;  set; }
        public string ProfilePhoto { get;  set; }
    }
}
