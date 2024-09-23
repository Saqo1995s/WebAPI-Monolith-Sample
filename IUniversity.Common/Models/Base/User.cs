using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IUniversity.Common.Models.Base
{
    public class User : EntityBase
    {
        [Required, MaxLength(50, ErrorMessage = "exceeded the character limit for this column")]
        public string FirstName { get; set; }

        [Required, MaxLength(50, ErrorMessage = "exceeded the character limit for this column")]
        public string LastName { get; set; }

        [NotMapped, JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";

        [Required, MaxLength(50, ErrorMessage = "exceeded the character limit for this column")]
        public string Email { get; set; }

        public Guid AccountId { get; set; }
    }
}