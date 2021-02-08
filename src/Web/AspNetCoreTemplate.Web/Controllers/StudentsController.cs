using AspNetCoreTemplate.Services.Data;
using AspNetCoreTemplate.Web.ViewModels.Students;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTemplate.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        public IActionResult Index() 
        {

            var viewModel = new StudentIndexViewModel
            {
                Students = studentsService.GetAll<StudentsViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
