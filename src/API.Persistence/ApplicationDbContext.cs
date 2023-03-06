using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(){}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Sale>? Sales { get; set; }
        public DbSet<SaleDetail>? SaleDetails { get; set; }
        public DbSet<Vendor>? Vendors { get; set; }
        public DbSet<Service>? Services { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasKey(p => new { p.Serie, p.Number });
            modelBuilder.Entity<SaleDetail>().HasKey(p => new { p.Serie, p.Number, p.ItemId });
            modelBuilder.Entity<Vendor>().HasKey(p => p.Id);
            modelBuilder.Entity<Service>().HasKey(p => p.Id);

            modelBuilder.Entity<Sale>().HasMany<SaleDetail>(p => p.SaleDetails);
            modelBuilder.Entity<Sale>().HasOne<Vendor>(p => p.Vendor);
            modelBuilder.Entity<SaleDetail>().HasOne<Service>(p => p.Service);
        }
    }
}

