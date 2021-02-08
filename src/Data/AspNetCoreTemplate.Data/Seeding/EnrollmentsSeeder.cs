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
            new Enrollment{StudentId=1,CourseId=1,Grade=Grade.A},
            new Enrollment{StudentId=1,CourseId=2,Grade=Grade.C},
            new Enrollment{StudentId=1,CourseId=1,Grade=Grade.B},
            new Enrollment{StudentId=2,CourseId=1,Grade=Grade.B},
            new Enrollment{StudentId=2,CourseId=2,Grade=Grade.F},
            new Enrollment{StudentId=2,CourseId=1,Grade=Grade.F},
            new Enrollment{StudentId=3,CourseId=4},
            new Enrollment{StudentId=4,CourseId=1},
            new Enrollment{StudentId=4,CourseId=5,Grade=Grade.F},
            new Enrollment{StudentId=5,CourseId=3,Grade=Grade.C},
            new Enrollment{StudentId=6,CourseId=3},
            new Enrollment{StudentId=7,CourseId=1,Grade=Grade.A},
           };
            foreach (Enrollment e in enrollments)
            {
               await dbContext.Enrollments.AddRangeAsync(e);
            }
        }
    }
}