using System.Text.Json.Serialization;

namespace APP.Models
{
    public class Service
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("unidad")]
        public string? Unidad { get; set; }
        [JsonPropertyName("moneda")]
        public string? Moneda { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }        
    }
}