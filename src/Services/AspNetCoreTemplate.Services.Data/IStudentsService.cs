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
        void RemoveStudent(int? id);

        IEnumerable<T> GetBySTudentName<T>(string searchString);
        IEnumerable<T> GetOrderedStudentsByLastNameDescending<T>();
        IEnumerable<T> GetOrderedStudentsByLastNameAscending<T>();
        IEnumerable<T> GetOrderedStudentsByEnrollmentDateDescending<T>();
        IEnumerable<T> GetOrderedStudentsByEnrollmentAscending<T>();
        Task CreateStudent(DateTime enrollmentDate, string firstName, string midName, string lastName);
        T GetStudentById<T>(int? id);
        Task UpdateStudent(int id, DateTime enrollmentDate, string firstName, string midName, string lastName);
    }
}
