using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Courses
{
    public class CoursesViewModel
    {
           public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
