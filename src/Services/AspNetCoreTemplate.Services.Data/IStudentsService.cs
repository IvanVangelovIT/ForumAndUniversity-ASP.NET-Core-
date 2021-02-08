using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IStudentsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
