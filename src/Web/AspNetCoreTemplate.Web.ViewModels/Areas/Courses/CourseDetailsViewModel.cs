using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Courses
{
    public class CourseDetailsViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public string UserId { get; set; }

    }
}
