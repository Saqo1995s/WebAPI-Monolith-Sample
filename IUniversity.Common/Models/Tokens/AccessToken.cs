using System;

namespace IUniversity.Common.Models.Tokens
{
    public class AccessToken
    {
        public string Value { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}