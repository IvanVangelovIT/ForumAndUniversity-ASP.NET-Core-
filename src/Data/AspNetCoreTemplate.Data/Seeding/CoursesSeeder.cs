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
            new Course{Title="Chemistry",Credits=3},
            new Course{Title="Microeconomics",Credits=3},
            new Course{Title="Macroeconomics",Credits=3},
            new Course{Title="Calculus",Credits=4},
            new Course{Title="Trigonometry",Credits=4},
            new Course{Title="Composition",Credits=3},
            new Course{Title="Literature",Credits=4}
           };
            foreach (Course c in courses)
            {
                await dbContext.Courses.AddAsync(c);
            }
        }
    }
}