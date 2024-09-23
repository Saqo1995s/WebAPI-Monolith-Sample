using Microsoft.AspNetCore.Identity;

namespace IUniversity.Common.Models.Base
{
    public class LearningPlatformIdentityUser : IdentityUser
    {
        [PersonalData]
        public string Role { get; set; }
    }
}