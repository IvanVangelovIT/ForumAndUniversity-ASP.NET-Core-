namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Student : BaseDeletableModel<int>
    {
        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }


        public string LastName { get; set; }


        public string FirstName { get; set; }



        public string MidName { get; set; }


        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
