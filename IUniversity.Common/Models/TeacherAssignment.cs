using System.ComponentModel.DataAnnotations;
using IUniversity.Common.Models.Base;

namespace IUniversity.Common.Models
{
    public class TeacherAssignment : EntityBase
    {
        [Required]
        public string Group { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int TeacherId { get; set; }
    }
}
