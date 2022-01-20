using _0_FramWork.BaseClass;

namespace Account.Management.Domain.Users
{
    public class Account : BaseEntity
    {
        public string Fullname { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
        public string ProfilePhoto { get; private set; }


        public Roles.Role Role { get; private set; }
    }
}
