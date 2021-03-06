using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Courses
{
    public class CourseTitleAndGradeViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Grade? EnrollmentsGrade { get; set; }
    }
}
