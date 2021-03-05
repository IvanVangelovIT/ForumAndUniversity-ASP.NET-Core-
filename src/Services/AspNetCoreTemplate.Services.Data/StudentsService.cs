using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public class StudentsService : IStudentsService
    {
        private readonly IDeletableEntityRepository<Student> studentsRepository;

        public StudentsService(IDeletableEntityRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public async Task<int> Create<T>(DateTime enrollmentDate, string firstName, string midName, string lastName)
        {
            var student = new Student()
            {
                EnrollmentDate = enrollmentDate,
                FirstName = firstName,
                LastName = lastName,
            };

            await this.studentsRepository.AddAsync(student);
            await this.studentsRepository.SaveChangesAsync();

            return student.Id;
        }

        public async Task<T> GetStudentById<T>(int? id)
        {
            var query =
                 this.studentsRepository
                 .All()
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefault();

            return query;
        }

        public async Task<IQueryable<T>> SeatchByName<T>(string searchString)
        {
            var students = this.studentsRepository
                .All()
                .Where(s =>
                            s.LastName.Contains(searchString)
                         || s.FirstName.Contains(searchString))
                .To<T>();

            return students;
        }
        public async Task Delete(int? id)
        {
            var student = studentsRepository
               .All()
               .Where(x => x.Id == id)
               .FirstOrDefault();

            this.studentsRepository.Delete(student);
            await this.studentsRepository.SaveChangesAsync();
        }
        public IQueryable<T> GetAll<T>()
        {
            IQueryable<Student> query =
                 this.studentsRepository.All();
            
            return query.To<T>();
        }

        public IQueryable<T> GetStudentsByName<T>(string searchString)
        {
            var student = studentsRepository
                .All()
                .Where(x => x.FirstName == searchString || x.LastName == searchString);


            return student.To<T>();
        }     
                  
        public async Task Update(int id, DateTime enrollmentDate, string firstName, string midName, string lastName)
        {
            var student = studentsRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            this.studentsRepository.Update(student);
            this.studentsRepository.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> OrderBy<T>(string sortOrder)
        {
            IQueryable<T> students;
            switch (sortOrder)
            {
                case "name_desc":
                     students = this.studentsRepository
                        .All()
                        .OrderByDescending(s => s.LastName)
                        .To<T>();
                    break;
                case "Date":
                    students = this.studentsRepository
                        .All()
                        .OrderBy(s => s.EnrollmentDate)
                        .To<T>(); 
                    break;
                case "date_desc":
                    students = this.studentsRepository
                        .All()
                        .OrderByDescending(s => s.EnrollmentDate)
                        .To<T>();
                    break;
                default:
                    students = this.studentsRepository
                        .All()
                        .OrderBy(s => s.LastName)
                        .To<T>();
                    break;
            }

            return students;
        }
    }
}
