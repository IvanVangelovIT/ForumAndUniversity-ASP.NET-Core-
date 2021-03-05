using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IStudentsService
    {
        IQueryable<T> GetAll<T>();
        Task<T> GetStudentById<T>(int? id);
        Task<int> Create<T>(DateTime enrollmentDate, string firstName, string midName, string lastName);
        Task Update(int id, DateTime enrollmentDate, string firstName, string midName, string lastName);
        Task Delete(int? id);

        Task<IQueryable<T>> SeatchByName<T>(string searchString);

        Task<IQueryable<T>> OrderBy<T>(string sortOrder);
    }
}
