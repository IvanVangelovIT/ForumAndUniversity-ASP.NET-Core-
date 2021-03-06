using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTechniquesRazor.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IHostApplicationLifetime applifetime;
        private readonly IConfigurationRoot ConfigRoot;

        public PrivacyModel(ILogger<PrivacyModel> logger,
            IHostApplicationLifetime applifetime,
            IConfiguration configRoot)
        {
            _logger = logger;
            this.applifetime = applifetime;
            ConfigRoot = (IConfigurationRoot)configRoot;
        }

        public ContentResult OnGet()
        {
            string str = "";
            foreach (var provider in ConfigRoot.Providers.ToList())
            {
                str += provider.ToString() + "\n";
            }

            return Content(str);
        }
    }
}
