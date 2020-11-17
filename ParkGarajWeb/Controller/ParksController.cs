using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkGarajWeb.Model;
using ParkGarajWeb.Services;
//Ürünler servis kontroll kur ürünler.cshtml ekle falan sonra staartup da videodaki yerleri yap servise yeni olanı yaz ....//

namespace ParkGarajWeb.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        public  ParksController(JsonFileParkService parkService)
        {
            this.ParkService = parkService;
        }
        public JsonFileParkService ParkService { get; }
        [HttpGet]
        public IEnumerable<Park> Get()
        {
            return ParkService.GetParks();
        }
        
    }
    
}
