namespace AspNetCoreTemplate.Web.Areas.University.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.PaginationLogic;
    using AspNetCoreTemplate.Web.ViewModels.Areas.Students;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("University")]
    public class StudentsController : BaseController
    {
        private readonly IStudentsService studentsService;

        public StudentsController(
            IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        // GET: University/Students
        public async Task<IActionResult> Index(
                                                string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var students = this.studentsService.GetAll<StudentViewModel>();

            if (!String.IsNullOrEmpty(searchString))
            {
                students = await this.studentsService.SeatchByName<StudentViewModel>(searchString);
            }

            students = await this.studentsService.OrderBy<StudentViewModel>(sortOrder);           

            int pageSize = 3;
            var studentFromPagination = await PaginatedList<StudentViewModel>.CreateAsync(students, pageNumber ?? 1, pageSize);
            return View(studentFromPagination);
        }

        // GET: University/Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = this.studentsService.GetStudentById<StudentViewModel>(id);

            return View(student);
        }

        // GET: University/Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: University/Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel input)
        {
            if (!ModelState.IsValid)
            {
                this.NotFound();
            }

            int id = await this.studentsService.Create<StudentViewModel>(input.EnrollmentDate, input.FirstName, input.MidName, input.LastName);
            return RedirectToAction(nameof(Index));
        }

        // GET: University/Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await this.studentsService.GetStudentById<StudentViewModel>(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

           // this.studentsService.Update();

            return View(RedirectToAction(nameof(Index)));
        }

        // GET: University/Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await this.studentsService
                .GetStudentById<StudentViewModel>(id);

            return View(student);
        }

        // POST: University/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.studentsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
