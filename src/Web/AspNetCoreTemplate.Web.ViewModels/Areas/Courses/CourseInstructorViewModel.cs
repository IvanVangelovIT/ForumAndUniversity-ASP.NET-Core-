using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Courses
{
    public class CourseInstructorViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //TODO
        public string DepartmentName { get; set; }
    }
}
