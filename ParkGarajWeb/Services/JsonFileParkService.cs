using Microsoft.AspNetCore.Hosting;
using ParkGarajWeb.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

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
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Park[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public void AddRating(string parkId,int rating)
        {
            var parks = GetParks();
            var query = parks.First(x => x.Id == parkId);

            if (query.Rating == null)
            {
                query.Rating = new int[] { rating };
            }
            else
            {
                var ratings = query.Rating.ToList();
                ratings.Add(rating);
                query.Rating = rating.ToArray();
            }
            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Park>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    parks
                    );

                    
            }
        }
    }

}
