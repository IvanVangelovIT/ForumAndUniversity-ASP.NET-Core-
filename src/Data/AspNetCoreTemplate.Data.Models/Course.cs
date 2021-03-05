using AspNetCoreTemplate.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreTemplate.Data.Models
{
    public class Course : BaseDeletableModel<int>
    {
        public Course()
        {
            this.Enrollments = new HashSet<Enrollment>();
            this.CourseAssignments = new HashSet<CourseAssignment>();
        }
        public string Title { get; set; }
        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}