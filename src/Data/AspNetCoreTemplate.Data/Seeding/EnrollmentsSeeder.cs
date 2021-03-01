using AspNetCoreTemplate.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Data.Seeding
{
    public class EnrollmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Enrollments.Any())
            {
                return;
            }

            var enrollments = new Enrollment[]
             {
                new Enrollment {
                    StudentId = dbContext.Students.Single(s => s.LastName == "Alexander").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Chemistry" ).Id,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentId = dbContext.Students.Single(s => s.LastName == "Alexander").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Microeconomics" ).Id,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentId = dbContext.Students.Single(s => s.LastName == "Alexander").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Macroeconomics" ).Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentId = dbContext.Students.Single(s => s.LastName == "Alonso").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Calculus" ).Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentId = dbContext.Students.Single(s => s.LastName == "Alonso").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Trigonometry" ).Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = dbContext.Students.Single(s => s.LastName == "Alonso").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Composition" ).Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = dbContext.Students.Single(s => s.LastName == "Anand").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Chemistry" ).Id
                    },
                    new Enrollment {
                    StudentId = dbContext.Students.Single(s => s.LastName == "Anand").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Microeconomics").Id,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentId = dbContext.Students.Single(s => s.LastName == "Barzdukas").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Chemistry").Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = dbContext.Students.Single(s => s.LastName == "Li").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Composition").Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = dbContext.Students.Single(s => s.LastName == "Justice").Id,
                    CourseId = dbContext.Courses.Single(c => c.Title == "Literature").Id,
                    Grade = Grade.B
                    }
             };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = dbContext.Enrollments.Where(
                    s =>
                            s.Student.Id == e.StudentId &&
                            s.Course.Id == e.CourseId).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    await dbContext.Enrollments.AddAsync(e);
                }
            }

           
        }
    }
}