﻿using Microsoft.AspNetCore.Hosting;
using ParkGarajWeb.Model;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ParkGarajWeb.Services
{
    public class JsonFileParkService
    {
        public JsonFileParkService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "parkgaraj.json"); }
        }
        public IEnumerable<Park> GetParks()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Park[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }   
}