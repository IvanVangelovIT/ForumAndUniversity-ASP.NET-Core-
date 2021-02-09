﻿using AspNetCoreTemplate.Data;
using AspNetCoreTemplate.Services.Data;
using AspNetCoreTemplate.Web.ViewModels.Courses;
using AspNetCoreTemplate.Web.ViewModels.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService studentsService;
        private readonly ICoursesService coursesService;
        private readonly ApplicationDbContext dbContext;

        public StudentsController(IStudentsService studentsService,
            ICoursesService coursesService,
            ApplicationDbContext dbContext)
        {
            this.studentsService = studentsService;
            this.coursesService = coursesService;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {

            var viewModel = new StudentIndexViewModel
            {
                Students = studentsService.GetAll<StudentsViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentsViewModel student)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            await this.studentsService.CreateStudent(student.EnrollmentDate, student.FirstName,student.MidName, student.LastName);
            return View(student);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //TODO Fixing CourseService
            //var coursesTakenByStudents = new CoursesTakenByStudentsViewModel()
            //{
            //    Courses = this.coursesService.GetCourseByStudentId<CourseTitleAndGradeViewModel>(id),
            //};

            //this.coursesService.GetCourseByStudentId(id);

            var student = await dbContext.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: StudentArea/Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = studentsService.GetStudentById<StudentsViewModel>(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: StudentArea/Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentsViewModel student)
        {
            var scholar = studentsService
                .DoStudentExist<StudentsViewModel>(student.Id);

            if (scholar == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {                
                return View(student);
            }

            await studentsService.UpdateStudent(student.Id, student.EnrollmentDate,student.FirstName, student.MidName,student.LastName);
            return RedirectToAction(nameof(Index));
        }
    }
}
