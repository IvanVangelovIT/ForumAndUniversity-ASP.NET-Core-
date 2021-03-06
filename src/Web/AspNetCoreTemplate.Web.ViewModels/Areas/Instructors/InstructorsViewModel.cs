using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Web.ViewModels.Areas.Courses;
using AspNetCoreTemplate.Web.ViewModels.Areas.Enrollments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Instructors
{
    public class InstructorsViewModel
    {
        public IEnumerable<InstructorViewModel> Instructors { get; set; }
        public IEnumerable<CourseInstructorViewModel> Courses { get; set; }
        public IEnumerable<EnrollmentViewModel> Enrollments { get; set; }
    }
}
