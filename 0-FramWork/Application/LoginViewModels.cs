using System.Collections.Generic;

namespace _0_FrameWork.Application
{
    public class LoginViewModels
    {

        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public List<int> Permissions { get; set; }

        public LoginViewModels()
        {
        }

        public LoginViewModels(long id, long roleId, string fullname, string username, string mobile
            , List<int> permissions)
        {
            Id = id;
            RoleId = roleId;
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            if(permissions != null)
            Permissions = permissions;
            Permissions = new List<int>();
        }
    }
}

