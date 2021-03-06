using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IDepartmentsService
    {
        IEnumerable<T> GetAll<T>();
        Task<T> GetDepartmentById<T>(int? id);
        Task<int> Create<T>(DateTime enrollmentDate, string firstName, string midName, string lastName);
        Task Delete(int? id);
    }
}
