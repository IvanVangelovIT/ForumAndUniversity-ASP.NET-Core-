using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public interface ICoursesService
    {
         Task<T> GetCourseByCourseId<T>(int? id);

        IEnumerable<T> GetAll<T>();
        Task Create(int Id, string userId, string Title, int Credits, int DepartmentId);

        Task Update(int id, string Title, int Credits, string DepartmentName);
        bool CourseExist(int? id);

        Task Delete(int? id);
    }
}
