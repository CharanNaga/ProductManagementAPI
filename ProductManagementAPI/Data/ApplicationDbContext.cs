using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Pass DbContext options to the base DbContext class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Represents the Products table in the SQL Server database
        public DbSet<Product> Products { get; set; }

        // Configure model rules and seed initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base class implementation first
            base.OnModelCreating(modelBuilder);

            // Configure Price column precision as decimal(18,2)
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            // Seed initial product data into the Products table
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.Parse("46586689-FD9B-4FBD-AE8B-B0425EB5C13D"), Name = "Wireless Mouse", Description = "2.4 GHz wireless optical mouse", Price = 799.00m, StockQuantity = 25, Category = "Electronics", IsActive = true, CreatedOn = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Product { Id = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDEF0"), Name = "Notebook", Description = "200-page ruled notebook", Price = 120.00m, StockQuantity = 100, Category = "Stationery", IsActive = true, CreatedOn = new DateTime(2026, 1, 2, 0, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}