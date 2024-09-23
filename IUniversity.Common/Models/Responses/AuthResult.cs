using System;
using System.Collections.Generic;

namespace IUniversity.Common.Models.Responses
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
        public string Role { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}