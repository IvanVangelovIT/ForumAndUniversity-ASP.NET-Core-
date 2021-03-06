using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using AspNetCoreTemplate.Web.ViewModels.Areas.Instructors;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public class InstructorsService : IInstructorsService
    {
        private readonly IDeletableEntityRepository<Instructor> instructorRepository;
        public InstructorsService(
            IDeletableEntityRepository<Instructor> instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }
        public async Task<IEnumerable> GetAll()
        {
           var query = await instructorRepository
                  .All()
                  .Include(i => i.OfficeAssignment)
                  .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Enrollments)
                            .ThenInclude(i => i.Student)
                  .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Department)
                  .AsNoTracking()
                  .OrderBy(i => i.LastName)
                  .ToListAsync();

            return query;
        }

        public async Task<Instructor> GetInstructorById(int? id)
        {
            var query = await instructorRepository
                 .All()
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();

            return query;
        }

        public async Task<T> GetInstructorById<T>(int? id)
        {
           var query =  await this.instructorRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task Create(string firstName, string LastName, DateTime HireDate)
        {

            var instructor = new Instructor
            {
                FirstMidName = firstName,
                LastName = LastName,
                HireDate = HireDate,
            };

            await this.instructorRepository.AddAsync(instructor);
            await this.instructorRepository.SaveChangesAsync();
        }

        public async Task Update(int id, string firstName, string LastName, DateTime HireDate)
        {
            var query = await this.instructorRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            query.FirstMidName = firstName;
            query.LastName = LastName;
            query.HireDate = HireDate;

            this.instructorRepository.Update(query);
            await this.instructorRepository.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var query = await this.instructorRepository
               .All()
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();

            this.instructorRepository.Delete(query);
            await this.instructorRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllInstructorsOnly<T>()
        {
            var query = await this.instructorRepository
                            .All()
                            .To<T>()
                            .ToListAsync();

            return query;

        }
    }
}
