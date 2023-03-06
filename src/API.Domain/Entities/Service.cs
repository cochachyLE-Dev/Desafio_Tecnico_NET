namespace API.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Unidad { get; set; }
        public string? Currency { get; set; }
        public double Price { get; set; }        
    }
}