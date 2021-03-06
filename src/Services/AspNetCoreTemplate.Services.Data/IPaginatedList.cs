using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IPaginatedList
    {
        Task<T> CreateAsync<T>(IQueryable source, int pageIndex, int pageSize);
    }
}
