namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDeletableEntityRepository<Department> departmentsRepository;

        public DepartmentsService(IDeletableEntityRepository<Department> departmentsRepository)
        {
            this.departmentsRepository = departmentsRepository;
        }
        
        public async Task Delete(int? id)
        {
            var query = departmentsRepository
               .All()
               .Where(x => x.Id == id)
               .FirstOrDefault();

            this.departmentsRepository.Delete(query);
            await this.departmentsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var depatments = this.departmentsRepository
                .All()
                .Include(x => x.Administrator)
                .OrderBy(x => x.Name);

            return depatments.To<T>().ToList();
        }


        public async Task<T> GetDepartmentById<T>(int? id)
        {
            var query =
                 this.departmentsRepository
                 .All()
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefault();

            return query;

        }

        public Task<int> Create<T>(DateTime enrollmentDate, string firstName, string midName, string lastName)
        {
            throw new NotImplementedException();
        }


        public Task Update(int id, DateTime enrollmentDate, string firstName, string midName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
