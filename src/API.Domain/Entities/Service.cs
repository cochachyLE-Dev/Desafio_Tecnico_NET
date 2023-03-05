namespace API.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Unidad { get; set; }
        public string? Moneda { get; set; }
        public double Price { get; set; }        
    }
}