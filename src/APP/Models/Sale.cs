using System.Text.Json.Serialization;

namespace APP.Models
{
    public class Sale
    {
        [JsonPropertyName("serie")]
        public string? Serie { get; set; }
        [JsonPropertyName("number")]
        public string? Number { get; set; }
        [JsonPropertyName("vendorId")]
        public int VendorId { get; set; }
        [JsonPropertyName("total")]
        public double Total { get; set; }
        [JsonPropertyName("dateOfIssue")]
        public DateTime DateOfIssue { get; set; }
        [JsonPropertyName("vendor")]
        public Vendor? Vendor { get; set; }
        [JsonPropertyName("saleDetails")]
        public List<SaleDetail>? SaleDetails { get; set; }
    }
}
