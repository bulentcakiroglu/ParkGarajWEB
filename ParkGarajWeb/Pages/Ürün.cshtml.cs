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
    public class ÜrünModel : PageModel
    {
        private readonly ILogger<ÜrünModel> _logger;
        public JsonUrunService ÜrünService;
        public IEnumerable<Ürün> Ürüns { get; private set; }

        public ÜrünModel(ILogger<ÜrünModel> logger,
            JsonUrunService ürünservice)
        {
            _logger = logger;
            ÜrünService = ürünservice;
        }

        public void OnGet()
        {
            Ürüns = ÜrünService.GetÜrüns();
        }
    }
}