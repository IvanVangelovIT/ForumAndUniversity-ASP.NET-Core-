using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreTemplate.Services.Data
{
    public class StudentsService : IStudentsService
    {
        private readonly IDeletableEntityRepository<Student> studentsRepository;

        public StudentsService(IDeletableEntityRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Student> query =
                 this.studentsRepository.All().OrderBy(x => x.CreatedOn);
            
            return query.To<T>().ToList();
        }
    }
}
