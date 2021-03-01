using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreTemplate.Web.ViewModels.Students
{
    public class StudentIndexViewModel
    {
        public IEnumerable<StudentsViewModel> Students { get; set; }
        public IQueryable<StudentsViewModel> Students2 { get; set; }
    }
}
