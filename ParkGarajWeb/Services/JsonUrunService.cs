using Microsoft.AspNetCore.Hosting;
using ParkGarajWeb.Model;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ParkGarajWeb.Services
{
    public class JsonUrunService
    {
        public JsonUrunService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "urun.json"); }
        }
        public IEnumerable<Ürün> GetÜrüns()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Ürün[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
