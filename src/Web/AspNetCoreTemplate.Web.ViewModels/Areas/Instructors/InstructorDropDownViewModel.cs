using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Instructors
{
    public class InstructorDropDownViewModel : IMapFrom<Instructor>
    {
        public int Id { get; set; }
        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public DateTime HireDate { get; set; }
    }
}
