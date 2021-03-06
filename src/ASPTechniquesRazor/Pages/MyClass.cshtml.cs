using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTechniquesRazor.Pages
{
    public class MyClassModel : PageModel
    {
        private readonly IHostApplicationLifetime _appLifetime;

        public MyClassModel(IHostApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;
        }

        public void Shutdown()
        {
            _appLifetime.StopApplication();
        }
    }
}
