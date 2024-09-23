using IUniversity.Common.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IUniversity.Common.Models
{
    public class Course : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }
        
        [Required]
        public string ShortDescription { get; set; }

        [DefaultValue(0)]
        public int Participants { get; set; }

        [DefaultValue(0)] 
        public int CoursePasses { get; set; }

        public int TeacherId { get; set; }

        [ForeignKey("TeacherId"), NotMapped, JsonIgnore]
        public virtual Teacher CourseTeacher { get; set; }
    }
}
