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

        public async Task CreateStudent(DateTime enrollmentDate, string firstName, string midName, string lastName)
        {
            var student = new Student()
            {
                EnrollmentDate = enrollmentDate,
                FirstName = firstName,
                LastName = lastName,
            };

            await this.studentsRepository.AddAsync(student);
            await this.studentsRepository.SaveChangesAsync();
        }

        public async Task<T> DoStudentExist<T>(int? id)
        {
            var student = studentsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return student;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Student> query =
                 this.studentsRepository.All();
            
            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetBySTudentName<T>(string searchString)
        {
            var student = studentsRepository
                .All()
                .Where(x => x.FirstName == searchString || x.LastName == searchString);


            return student.To<T>().ToList();
        }

        public IEnumerable<T> GetOrderedStudentsByEnrollmentAscending<T>()
        {
            var students = studentsRepository
               .All()
               .OrderBy(x => x.EnrollmentDate);
            
            return students.To<T>().ToList();
        }

        public IEnumerable<T> GetOrderedStudentsByEnrollmentDateDescending<T>()
        {
            var students = studentsRepository
               .All()
               .OrderByDescending(x => x.EnrollmentDate);

            return students.To<T>().ToList();
        }
        

        public IEnumerable<T> GetOrderedStudentsByLastNameAscending<T>()
        {
            var students = studentsRepository
                .All()
                .OrderBy(x => x.LastName);

            return students.To<T>().ToList();
        }

        public IEnumerable<T> GetOrderedStudentsByLastNameDescending<T>()
        {
            var students = studentsRepository
                .All()
                .OrderByDescending(x => x.LastName);

            return students.To<T>().ToList();
        }

        public T GetStudentById<T>(int? id)
        {
            var query =
                 this.studentsRepository
                 .All()
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefault();

            return query;
        }

        public void RemoveStudent(int? id)
        {
            var student = studentsRepository
               .All()
               .Where(x => x.Id == id)
               .FirstOrDefault();

             studentsRepository.Delete(student);
        }

        public async Task UpdateStudent(int id, DateTime enrollmentDate, string firstName, string midName, string lastName)
        {
            var student = studentsRepository
                .All()
                .Where(x => x.EnrollmentDate == enrollmentDate)
                .FirstOrDefault();

            studentsRepository.Update(student);
            await this.studentsRepository.SaveChangesAsync();
        }
    }
}
