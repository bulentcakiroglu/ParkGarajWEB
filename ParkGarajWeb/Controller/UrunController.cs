using Microsoft.AspNetCore.Mvc;
using ParkGarajWeb.Model;
using ParkGarajWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace ParkGarajWeb.Controller
{
    public class UrunController:ControllerBase
    {
        public UrunController(JsonUrunService ürünService)
        {
            this.ÜrünService = ürünService;
        }

        
        public JsonUrunService ÜrünService { get; }

        public IEnumerable<Ürün> Get()
        {
            return ÜrünService.GetÜrüns();
        }
    }
}
