namespace API.Domain.Entities
{
    // Asesores comerciales (Vendedores)
    public class Vendor
    {
        public int Id { get; set; }        
        public string? Name { get; set; }
        public string? Role { get; set; }
        public bool OutSourced { get; set; }
        public bool Active { get; set; }        
    }
}