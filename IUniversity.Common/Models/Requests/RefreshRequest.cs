using System.ComponentModel.DataAnnotations;

namespace IUniversity.Common.Models.Requests
{
     public class RefreshRequest
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}