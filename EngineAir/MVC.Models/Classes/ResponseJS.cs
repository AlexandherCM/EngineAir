using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MVC.Models.Classes
{
    public class ResponseJS
    {
        [JsonPropertyName("Leyenda")]
        public string Leyenda { get; set; } = string.Empty;

        [JsonPropertyName("Estado")]
        public bool Estado { get; set; }

        [JsonPropertyName("Body")]
        public string Body { get; set; } = string.Empty; 
    }  
}
