using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public class CoursesService : ICoursesService
    {
        private readonly IDeletableEntityRepository<Course> coursesRepository;

        public CoursesService(IDeletableEntityRepository<Course> coursesRepository)
        {
            this.coursesRepository = coursesRepository;
        }

        public async Task Create(int Id, string userId, string Title, int Credits, int DepartmentId)
        {
            var course = new Course
            {
                Id = Id,
                UserId = userId,
                Title = Title,
                Credits = Credits,
                DepartmentId = DepartmentId,
            };

            await this.coursesRepository.AddAsync(course);
            await this.coursesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Course> query = this.coursesRepository
                .All()
                .OrderBy(x => x.Credits);

            return query.To<T>().ToList();
        }

        public async Task<T> GetCourseByCourseId<T>(int? id)
        {
            var query = this.coursesRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return query;
        }

        public async Task Update(int Id, string Title, int Credits, string DepartmentName)
        {
            var course = await this.coursesRepository
                .All()
                .Where(x => x.Id == Id)
                .Include(x => x.Department)
                .FirstOrDefaultAsync();
            
            course.Title = Title;
            course.Credits = Credits;
            course.Department.Name = DepartmentName;

            this.coursesRepository.Update(course);
            await this.coursesRepository.SaveChangesAsync();
        }

        public bool CourseExist(int? id)
        {
            return this.coursesRepository
                .All()
                .Any(x => x.Id == id);
        }

        public async Task Delete(int? id)
        {
            var course = this.coursesRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            this.coursesRepository.Delete(course);
            await this.coursesRepository.SaveChangesAsync();
        }
    }
}
