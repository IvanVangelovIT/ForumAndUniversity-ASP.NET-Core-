using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using AspNetCoreTemplate.Web.ViewModels.Areas.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Enrollments
{
    public class EnrollmentViewModel : IMapFrom<Enrollment>
    {
        public StudentViewModel Student { get; set; }
    }
}
