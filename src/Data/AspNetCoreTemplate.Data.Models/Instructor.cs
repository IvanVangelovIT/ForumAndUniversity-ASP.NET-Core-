namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Instructor : BaseDeletableModel<int>
    {
        public Instructor()
        {
            this.CourseAssignments = new HashSet<CourseAssignment>();
        }

        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public DateTime HireDate { get; set; }

        public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}
