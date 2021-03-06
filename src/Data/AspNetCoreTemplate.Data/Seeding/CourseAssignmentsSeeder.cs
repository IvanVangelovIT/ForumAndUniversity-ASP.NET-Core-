using AspNetCoreTemplate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Data.Seeding
{
    class CourseAssignmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CourseAssignments.Any())
            {
                return;
            }

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseId = dbContext.Courses.Single(c => c.Title == "Chemistry" ).Id,
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Kapoor").Id
                    },
                new CourseAssignment {
                    CourseId = dbContext.Courses.Single(c => c.Title == "Chemistry" ).Id,
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Harui").Id
                    },
                new CourseAssignment {
                    CourseId = dbContext.Courses.Single(c => c.Title == "Microeconomics" ).Id,
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Zheng").Id
                    },
                new CourseAssignment {
                    CourseId = dbContext.Courses.Single(c => c.Title == "Macroeconomics" ).Id,
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Zheng").Id
                    },
                new CourseAssignment {
                    CourseId = dbContext.Courses.Single(c => c.Title == "Calculus" ).Id,
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Fakhouri").Id
                    },
                new CourseAssignment {
                    CourseId = dbContext.Courses.Single(c => c.Title == "Trigonometry" ).Id,
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Harui").Id
                    },
                new CourseAssignment {
                    CourseId = dbContext.Courses.Single(c => c.Title == "Composition" ).Id,
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Abercrombie").Id
                    },
                new CourseAssignment {
                    CourseId = dbContext.Courses.Single(c => c.Title == "Literature" ).Id,
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Abercrombie").Id
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                await dbContext.CourseAssignments.AddAsync(ci);
            }
        }
    }
}
