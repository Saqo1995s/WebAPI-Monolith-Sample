using IUniversity.Common.Models.Base;

namespace IUniversity.Common.Models
{
    public class UserInfo
    {
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public User User { get; set; }
    }
}
