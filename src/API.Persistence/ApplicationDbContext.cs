using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(){}        
        public DbSet<Sale>? Sales { get; set; }
        public DbSet<SaleDetail>? SaleDetails { get; set; }
        public DbSet<Seller>? Sellers { get; set; }
        public DbSet<Service>? Services { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasKey(p => new { p.Serie, p.Number });
            modelBuilder.Entity<SaleDetail>().HasKey(p => new { p.Serie, p.Number, p.ItemId });
            modelBuilder.Entity<Seller>().HasKey(p => p.Id);
            modelBuilder.Entity<Service>().HasKey(p => p.Id);

            modelBuilder.Entity<Sale>().HasMany<SaleDetail>(p => p.SaleDetails);
            modelBuilder.Entity<Sale>().HasOne<Seller>(p => p.Seller);
            modelBuilder.Entity<SaleDetail>().HasOne<Service>(p => p.Service);
        }
    }
}

