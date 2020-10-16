using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkGarajWeb.Model;
using ParkGarajWeb.Services;

namespace ParkGarajWeb.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        public ParksController(JsonFileParkService parkService)
        {
            this.ParkService = parkService;
        }
        public JsonFileParkService ParkService { get; }
        [HttpGet]
        public IEnumerable<Park> Get()
        {
            return ParkService.GetParks();
        }
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string ParkId ,
            [FromQuery] int Rating)
        {
            ParkService.AddRating(ParkId, Rating);
            return Ok();
        }
    }
}
