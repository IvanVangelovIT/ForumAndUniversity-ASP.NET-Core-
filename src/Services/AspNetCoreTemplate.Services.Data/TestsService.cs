using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreTemplate.Services.Data
{
    public class TestsService : ITestService
    {
        private readonly IDeletableEntityRepository<Student> studentsRepository;

        public TestsService(IDeletableEntityRepository<Student> studentsRepository)
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
