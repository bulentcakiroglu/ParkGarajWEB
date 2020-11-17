using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ParkGarajWeb.Model;
using ParkGarajWeb.Services;

namespace ParkGarajWeb.Pages
{
    public class AnasayfaModel : PageModel
    {
        private readonly ILogger<AnasayfaModel> _logger;
        

        public AnasayfaModel(ILogger<AnasayfaModel> logger)
            
        {
            _logger = logger;
            
        }

        public void OnGet()
        {
            

        }
    }
}
