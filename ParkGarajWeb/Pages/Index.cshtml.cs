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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileParkService ParkService;
        public IEnumerable<Park> Parks { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileParkService parkService)
        {
            _logger = logger;
            ParkService = parkService;
        }

        public void OnGet()
        {
            Parks = ParkService.GetParks();

        }
    }
}
