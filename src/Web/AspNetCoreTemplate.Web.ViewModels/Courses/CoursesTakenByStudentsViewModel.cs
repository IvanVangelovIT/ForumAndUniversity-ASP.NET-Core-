using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Courses
{
    public class CoursesTakenByStudentsViewModel
    {
        public IEnumerable<CourseTitleAndGradeViewModel> Courses { get; set; }
    }
}
