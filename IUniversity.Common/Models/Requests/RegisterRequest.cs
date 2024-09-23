using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IUniversity.Common.Models.Requests
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [AllowNull]
        public string Role { get; set; }

        [AllowNull]
        public string Group { get; set; }
    }
}