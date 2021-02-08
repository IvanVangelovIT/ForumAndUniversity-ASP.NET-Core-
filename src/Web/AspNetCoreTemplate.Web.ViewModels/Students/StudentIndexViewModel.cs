using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Students
{
    public class StudentIndexViewModel
    {
        public IEnumerable<StudentsViewModel> Students { get; set; }
    }
}
