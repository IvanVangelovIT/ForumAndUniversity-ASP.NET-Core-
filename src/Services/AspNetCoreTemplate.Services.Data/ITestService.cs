using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Services.Data
{
    public interface ITestService
    {
        IEnumerable<T> GetAll<T>();
    }

}
