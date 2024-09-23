using IUniversity.Common.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace IUniversity.Common.Models
{
    public class Student : User
    {
        [Required, MaxLength(50, ErrorMessage = "exceeded the character limit for this column")]
        public string Group { get; set; }
    }
}
