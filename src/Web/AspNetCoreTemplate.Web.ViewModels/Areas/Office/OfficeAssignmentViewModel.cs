using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Areas.Office
{
    public class OfficeAssignmentViewModel : IMapFrom<OfficeAssignment>
    {
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }
    }
}
