using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Departments
{
    public class DepartmentDropDownViewModel : IMapFrom<Department>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
