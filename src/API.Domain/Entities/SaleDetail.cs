namespace API.Domain.Entities
{
    public class SaleDetail
    {
        public string? Serie { get; set; }
        public string? Number { get; set; }
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
