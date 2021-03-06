using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Courses
{
    public class CourseAssigmentViewModel : IMapFrom<CourseAssignment>
    {
        public CourseInstructorViewModel Course { get; set; }

    }
}
