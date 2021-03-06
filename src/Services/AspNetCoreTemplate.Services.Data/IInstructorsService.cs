namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IInstructorsService
    {
         Task<IEnumerable> GetAll();
         Task<IEnumerable<T>> GetAllInstructorsOnly<T>();
         Task<T> GetInstructorById<T>(int? id);
         Task Create(string firstName, string LastName, DateTime HireDate);
         Task Update(int id, string firstName, string LastName, DateTime HireDate);
         Task Delete(int? id);
    }
}
