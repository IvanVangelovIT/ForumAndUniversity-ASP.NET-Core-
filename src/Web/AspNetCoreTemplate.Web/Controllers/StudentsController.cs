using AspNetCoreTemplate.Data;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Data;
using AspNetCoreTemplate.Web.PaginationLogic;
using AspNetCoreTemplate.Web.ViewModels.Courses;
using AspNetCoreTemplate.Web.ViewModels.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var studentsViewModel = new StudentIndexViewModel
            {
                Students = studentsService.GetAll<StudentsViewModel>(),
            };           

            switch (sortOrder)
            {
                case "name_desc":
                    studentsViewModel.Students = studentsService
                        .GetOrderedStudentsByLastNameDescending<StudentsViewModel>();
                    break;
                case "Date":
                    studentsViewModel.Students = studentsService
                         .GetOrderedStudentsByEnrollmentAscending<StudentsViewModel>();
                    break;
                case "date_desc":
                    studentsViewModel.Students = studentsService
                         .GetOrderedStudentsByEnrollmentDateDescending<StudentsViewModel>();
                    break;
                default:
                    studentsViewModel.Students = studentsService
                         .GetOrderedStudentsByLastNameAscending<StudentsViewModel>();
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsViewModel.Students = studentsService.GetBySTudentName<StudentsViewModel>(searchString);
                //return this.View(Students);
            }


            return this.View(studentsViewModel);
        }

        public async Task<IActionResult> Index2(
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

           
            var studentsViewModel = new StudentIndexViewModel
            {
                Students = studentsService.GetAll<StudentsViewModel>(),
            };

            switch (sortOrder)
            {
                case "name_desc":
                    studentsViewModel.Students = studentsService
                        .GetOrderedStudentsByLastNameDescending<StudentsViewModel>();
                    break;
                case "Date":
                    studentsViewModel.Students = studentsService
                         .GetOrderedStudentsByEnrollmentAscending<StudentsViewModel>();
                    break;
                case "date_desc":
                    studentsViewModel.Students = studentsService
                         .GetOrderedStudentsByEnrollmentDateDescending<StudentsViewModel>();
                    break;
                default:
                    studentsViewModel.Students = studentsService
                         .GetOrderedStudentsByLastNameAscending<StudentsViewModel>();
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsViewModel.Students = studentsService.GetBySTudentName<StudentsViewModel>(searchString);
            }

            int pageSize = 3;
            return View(await PaginatedList<StudentsViewModel>.CreateAsync((IQueryable<StudentsViewModel>)studentsViewModel.Students.ToList(), pageNumber ?? 1, pageSize));
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
