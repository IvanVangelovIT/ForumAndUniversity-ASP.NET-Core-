using AspNetCoreTemplate.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Data.Models
{
    public class Enrollment : BaseDeletableModel<int>
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
