//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using AspNetCoreTemplate.Data;
//using AspNetCoreTemplate.Data.Models;
//using AspNetCoreTemplate.Web.PaginationLogic;
//using AspNetCoreTemplate.Services.Data;

//namespace AspNetCoreTemplate.Web.Areas.University.Controllers
//{
//    [Area("University")]
//    public class StudentsControllerTest : BaseController
//    {
//        private readonly IStudentsService studentsService;

//        public StudentsControllerTest(IStudentsService studentsService)
//        {
//            this.studentsService = studentsService;
//        }

//        // GET: University/Students
//        public async Task<IActionResult> Index(
//                 string sortOrder,
//                 string currentFilter,
//                 string searchString,
//                 int? pageNumber)
//        {
//            ViewData["CurrentSort"] = sortOrder;
//            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
//            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

//            if (searchString != null)
//            {
//                pageNumber = 1;
//            }
//            else
//            {
//                searchString = currentFilter;
//            }

//            ViewData["CurrentFilter"] = searchString;

//            var students = from s in _context.Students
//                           select s;
//            if (!String.IsNullOrEmpty(searchString))
//            {
//                students = students.Where(s => s.LastName.Contains(searchString)
//                                        || s.FirstName.Contains(searchString));
//            }
//            switch (sortOrder)
//            {
//                case "name_desc":
//                    students = students.OrderByDescending(s => s.LastName);
//                    break;
//                case "Date":
//                    students = students.OrderBy(s => s.EnrollmentDate);
//                    break;
//                case "date_desc":
//                    students = students.OrderByDescending(s => s.EnrollmentDate);
//                    break;
//                default:
//                    students = students.OrderBy(s => s.LastName);
//                    break;
//            }

//            int pageSize = 3;
//            return View(await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
//        }

//        // GET: University/Students/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // GET: University/Students/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: University/Students/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("LastName,FirstName,MidName,EnrollmentDate,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Student student)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(student);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // GET: University/Students/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students.FindAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return View(student);
//        }

//        // POST: University/Students/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("LastName,FirstName,MidName,EnrollmentDate,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Student student)
//        {
//            if (id != student.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(student);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StudentExists(student.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // GET: University/Students/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // POST: University/Students/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var student = await _context.Students.FindAsync(id);
//            _context.Students.Remove(student);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool StudentExists(int id)
//        {
//            return _context.Students.Any(e => e.Id == id);
//        }
//    }
//}
