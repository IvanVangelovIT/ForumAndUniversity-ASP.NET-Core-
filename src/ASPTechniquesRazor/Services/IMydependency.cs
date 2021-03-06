using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTechniquesRazor.Services
{
    public interface IMyDependency
    {
        void WriteMessage(string message);
    }
}
