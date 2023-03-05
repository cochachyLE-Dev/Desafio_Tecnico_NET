using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Sale> Sales { get; set; }
        DbSet<SaleDetail> SaleDetails { get; set; }
        DbSet<Seller> Sellers { get; set; }
        DbSet<Service> Services { get; set; }

        Task<int> SaveChangesAsync();
    }
}
