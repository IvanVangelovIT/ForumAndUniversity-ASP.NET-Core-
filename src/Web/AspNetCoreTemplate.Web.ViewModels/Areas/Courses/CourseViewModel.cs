using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using AspNetCoreTemplate.Web.ViewModels.Areas.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Courses
{
    public class CourseViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        [Display(Name = "Deparment Name")]
        public string DepartmentName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int? DepartmentId { get; set; }
        public IEnumerable<DepartmentDropDownViewModel> Departments { get; set; }

    }
}