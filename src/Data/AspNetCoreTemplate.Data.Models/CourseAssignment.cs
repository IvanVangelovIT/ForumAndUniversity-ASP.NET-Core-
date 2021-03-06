using AspNetCoreTemplate.Data.Common.Models;

namespace AspNetCoreTemplate.Data.Models
{
    public class CourseAssignment : BaseDeletableModel<int>
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }
    }
}