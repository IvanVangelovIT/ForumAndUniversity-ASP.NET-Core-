using AspNetCoreTemplate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Data.Seeding
{
    public class OfficeAssignmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.OfficeAssignments.Any())
            {
                return;
            }

            var officeAssignments = new OfficeAssignment[]
           {
             new OfficeAssignment {
                 InstructorId = dbContext.Instructors.Single(i => i.LastName == "Fakhouri").Id, Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Harui").Id, Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorId = dbContext.Instructors.Single(i => i.LastName == "Kapoor").Id, Location = "Thompson 304" },
           };
            foreach (OfficeAssignment o in officeAssignments)
            {
                await dbContext.OfficeAssignments.AddAsync(o);
            }
        }
    }
}
