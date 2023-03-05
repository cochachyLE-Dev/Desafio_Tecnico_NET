using System.Collections.Generic;

namespace API.Domain.Entities
{
    public class Sale
    {        
        public string? Serie { get; set; }
        public string? Number { get; set; }
        public int SellerId { get; set; }
        public double Total { get; set; }

        public Seller? Seller { get; set; }
        public List<SaleDetail>? SaleDetails { get; set; }
    }
}
