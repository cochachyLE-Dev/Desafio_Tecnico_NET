using System.Text.Json.Serialization;

namespace APP.Models
{
    public class SaleDetail
    {
        [JsonPropertyName("serie")]
        public string? Serie { get; set; }
        [JsonPropertyName("number")]
        public string? Number { get; set; }
        [JsonPropertyName("itemId")]
        public int ItemId { get; set; }
        [JsonPropertyName("itemName")]
        public string? ItemName { get; set; }
        [JsonPropertyName("qty")]
        public int Qty { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
        [JsonPropertyName("total")]
        public double Total { get; set; }
        [JsonPropertyName("serviceId")]
        public int ServiceId { get; set; }
        [JsonPropertyName("service")]
        public Service? Service { get; set; }
    }
}
