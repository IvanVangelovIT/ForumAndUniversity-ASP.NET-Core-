using AspNetCoreTemplate.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreTemplate.Data.Models
{
    public class Course : BaseDeletableModel<int>
    {
        public Course()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}