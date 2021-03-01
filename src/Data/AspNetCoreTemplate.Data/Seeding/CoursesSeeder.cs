using AspNetCoreTemplate.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Data.Seeding
{
    internal class CoursesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Courses.Any())
            {
                return;
            }

            var courses = new Course[]
           {
             new Course { Title = "Chemistry",  Credits = 3,
                    DepartmentId = dbContext.Departments.Single( s => s.Name == "Engineering").Id
                },
                new Course { Title = "Microeconomics", Credits = 3,
                    DepartmentId = dbContext.Departments.Single( s => s.Name == "Economics").Id
                },
                new Course { Title = "Macroeconomics", Credits = 3,
                    DepartmentId = dbContext.Departments.Single( s => s.Name == "Economics").Id
                },
                new Course { Title = "Calculus",       Credits = 4,
                    DepartmentId = dbContext.Departments.Single( s => s.Name == "Mathematics").Id
                },
                new Course { Title = "Trigonometry",   Credits = 4,
                    DepartmentId = dbContext.Departments.Single( s => s.Name == "Mathematics").Id
                },
                new Course { Title = "Composition",    Credits = 3,
                    DepartmentId = dbContext.Departments.Single( s => s.Name == "English").Id
                },
                new Course { Title = "Literature",     Credits = 4,
                    DepartmentId = dbContext.Departments.Single( s => s.Name == "English").Id
                },
           };
            foreach (Course c in courses)
            {
                await dbContext.Courses.AddAsync(c);
            }
        }
    }
}