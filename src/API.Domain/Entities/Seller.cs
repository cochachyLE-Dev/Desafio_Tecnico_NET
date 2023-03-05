namespace API.Domain.Entities
{
    // Asesores comerciales (Vendedores)
    public class Seller
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}