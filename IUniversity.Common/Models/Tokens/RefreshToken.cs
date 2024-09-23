using System;
using System.ComponentModel.DataAnnotations.Schema;
using IUniversity.Common.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace IUniversity.Common.Models.Tokens
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public LearningPlatformIdentityUser User { get; set; }
    }
}