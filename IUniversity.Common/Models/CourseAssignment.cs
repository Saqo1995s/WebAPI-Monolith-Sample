using System.ComponentModel.DataAnnotations;
using IUniversity.Common.Models.Base;

namespace IUniversity.Common.Models
{
    public class CourseAssignment : EntityBase
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Group { get; set; }
    }
}
