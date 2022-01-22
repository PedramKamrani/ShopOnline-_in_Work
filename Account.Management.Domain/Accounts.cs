using _0_FramWork.BaseClass;

namespace Account.Management.Domain
{
    public class Accounts : BaseEntity
    {
        
        public Accounts(string fullname, string userName, string password, string mobile, long roleId, string profilePhoto)
        {
            Fullname = fullname;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            if (profilePhoto != null)
                ProfilePhoto = profilePhoto;
        }

        public string Fullname { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
        public string ProfilePhoto { get; private set; }
        public Role Role { get; private set; }

        public void Edit(string fullname, string userName, string password, string mobile, long roleId, string profilePhoto)
        {
            Fullname = fullname;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            if (profilePhoto != null)
                ProfilePhoto = profilePhoto;
        }
    }
}
