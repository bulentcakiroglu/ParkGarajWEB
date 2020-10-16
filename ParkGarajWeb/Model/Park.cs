using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParkGarajWeb.Model
{
    public class Park
    {
        public string Id { get; set; }
        
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        public string Image{ get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public int[] Rating { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Park>(this);
       
    }
}
