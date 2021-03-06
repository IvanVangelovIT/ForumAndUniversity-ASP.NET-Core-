namespace AspNetCoreTemplate.Web.Areas.University.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Areas.Courses;
    using AspNetCoreTemplate.Web.ViewModels.Areas.Departments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("University")]
    public class CoursesController : BaseController
    {
        private readonly ICoursesService coursesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDepartmentsService departmentsService;

        public CoursesController(
            ICoursesService coursesService,
            UserManager<ApplicationUser> userManager,
            IDepartmentsService departmentsService)
        {
            this.coursesService = coursesService;
            this.userManager = userManager;
            this.departmentsService = departmentsService;
        }

        public IActionResult Index()
        {
            var courses = this.coursesService.GetAll<CourseViewModel>();
            var viewModel = new CoursesViewModel
            {
                Courses = courses,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vieModel = await this.coursesService.GetCourseByCourseId<CourseDetailsViewModel>(id);

            if (vieModel == null)
            {
                return NotFound();
            }

            return View(vieModel);
        }

        public IActionResult Create()
        {
            var departments = this.departmentsService.GetAll<DepartmentDropDownViewModel>();
            var viewModel = new CourseViewModel
            {
                Departments = departments,
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CourseDetailsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.coursesService.Create(input.Id, userId, input.Title, input.Credits, input.DepartmentId);
            this.TempData["InfoMessage"] = "Course created!";
            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await this.coursesService.GetCourseByCourseId<CourseViewModel>(id);
            var departments = this.departmentsService.GetAll<DepartmentDropDownViewModel>();
            var viewModel = new CourseViewModel
            {
                Title = course.Title,
                Credits = course.Credits,
                Departments = departments,
            };
            if (course == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, CourseViewModel input)
        {
            bool courseExist = this.coursesService.CourseExist(id);
            if (id == null || courseExist == false)
            {
                return NotFound();
            }
         
            if (!ModelState.IsValid)
            {              
                return NotFound();                                  
            }

            var department = await this.departmentsService.GetDepartmentById<DepartmentViewModel>(input.DepartmentId);
            await this.coursesService.Update(id, input.Title, input.Credits, department.Name);
            this.TempData["InfoMessageUpdatetCourse"] = "Course updatet successfully!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await this.coursesService.GetCourseByCourseId<CourseViewModel>(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.coursesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
