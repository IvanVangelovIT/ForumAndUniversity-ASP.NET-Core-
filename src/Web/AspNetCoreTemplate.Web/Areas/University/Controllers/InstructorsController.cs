namespace AspNetCoreTemplate.Web.Areas.University.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Areas.Instructors;
    using AspNetCoreTemplate.Web.ViewModels.Instructors;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("University")]
    public class InstructorsController : BaseController
    {
        private readonly IInstructorsService instructorService;

        public InstructorsController(
            IInstructorsService instructorService)
        {
            this.instructorService = instructorService;
        }

        // GET: University/Instructors
        public async Task<IActionResult> Index(int? id, int? courseID)
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors = (IEnumerable<Instructor>) await this.instructorService.GetAll();

            var instructorsViewModel = viewModel.Instructors;

            if (id != null)
            {
                ViewData["InstructorID"] = id.Value;
                viewModel.Courses = viewModel.Instructors.Where(i => i.Id == id.Value).FirstOrDefault().CourseAssignments.Select(c => c.Course);
            }

            if (courseID != null)
            {
                ViewData["CourseID"] = courseID.Value;
                viewModel.Enrollments = viewModel.Courses.Where(x => x.Id == courseID).Single().Enrollments;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await this.instructorService.GetInstructorById<InstructorViewModel>(id);
          
            return View(instructor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(InstructorViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            await this.instructorService.Create(input.FirstMidName, input.LastName, input.HireDate);

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await this.instructorService
                .GetInstructorById<InstructorViewModel>(id);

            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InstructorViewModel input)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            await this.instructorService.Update(id, input.FirstMidName, input.LastName, input.HireDate);
            this.TempData["InfoMessageUpdatetCourse"] = "Course updatet successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: University/Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await this.instructorService
                .GetInstructorById<InstructorViewModel>(id);         

            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var instructor = await this.instructorService.GetInstructorById<InstructorViewModel>(id);
            await this.instructorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
