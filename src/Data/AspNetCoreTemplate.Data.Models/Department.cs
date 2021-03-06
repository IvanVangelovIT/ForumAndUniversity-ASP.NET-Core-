using AspNetCoreTemplate.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreTemplate.Data.Models
{
    public class Department : BaseDeletableModel<int>
    {
        public Department()
        {
            this.Courses = new HashSet<Course>();
        }

        public string Name { get; set; }

        public decimal Budget { get; set; }


        public DateTime StartDate { get; set; }

        public int? InstructorId { get; set; }

        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}