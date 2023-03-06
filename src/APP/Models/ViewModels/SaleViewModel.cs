using APP.Shared;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.Text.Json.Serialization;

namespace APP.Models.ViewModels
{
    public class SaleViewModel    
    {        
        public SelectList? Vendors { get; set; }
        public string? VendorName { get; set; }
        public string? SearchString { get; set; }
        public IEnumerable<Sale>? Sales { get; set; }
    }
}
