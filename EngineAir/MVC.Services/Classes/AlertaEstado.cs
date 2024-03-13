using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MVC.Services.Classes
{
    public class AlertaEstado
    {
        [JsonPropertyName("Leyenda")]
        public string Leyenda { get; set; } = string.Empty;

        [JsonPropertyName("Estado")]
        public bool Estado { get; set; }
    }
}
