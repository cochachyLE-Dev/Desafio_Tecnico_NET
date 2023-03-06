using System.ComponentModel;
using System.Text.Json.Serialization;

namespace APP.Models
{
    // Asesores comerciales (Vendedores)
    public class Vendor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        [DisplayName("Business advisor / Vendor")]
        public string? Name { get; set; }
        [JsonPropertyName("role")]
        public string? Role { get; set; }
        [JsonPropertyName("outSourced")]
        public bool OutSourced { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }        
    }
}