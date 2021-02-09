using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IStudentsService
    {
        IEnumerable<T> GetAll<T>();
        Task<T> DoStudentExist<T>(int? id);
        Task<T> RemoveStudent<T>(int? id);

        Task CreateStudent(DateTime enrollmentDate, string firstName, string midName, string lastName);
        T GetStudentById<T>(int? id);
        Task UpdateStudent(int id, DateTime enrollmentDate, string firstName, string midName, string lastName);
    }
}
