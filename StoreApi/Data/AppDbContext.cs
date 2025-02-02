using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StoreApi.Entities;

namespace StoreApi.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Product> Products { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];

            optionsBuilder.UseSqlServer(connectionString);

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(
                new Product { IdProduct = 1, Name = "Laptop", Description = "High performance laptop" },
                new Product { IdProduct = 2, Name = "Smartphone", Description = "Latest model smartphone" },
                new Product { IdProduct = 3, Name = "Headphones", Description = "Noise-cancelling headphones" },
                new Product { IdProduct = 4, Name = "Monitor", Description = "4K Ultra HD monitor" },
                new Product { IdProduct = 5, Name = "Keyboard", Description = "Mechanical keyboard" },
                new Product { IdProduct = 6, Name = "Mouse", Description = "Wireless mouse" }
            );

            modelBuilder.Entity<Batch>().HasData(
                new Batch { IdBatch = 1, IdProduct = 1, EntryDate = DateTime.Now, Price = 1000.00m, Quantity = 10 },
                new Batch { IdBatch = 2, IdProduct = 2, EntryDate = DateTime.Now, Price = 800.00m, Quantity = 20 },
                new Batch { IdBatch = 3, IdProduct = 3, EntryDate = DateTime.Now, Price = 200.00m, Quantity = 30 },
                new Batch { IdBatch = 4, IdProduct = 4, EntryDate = DateTime.Now, Price = 400.00m, Quantity = 15 },
                new Batch { IdBatch = 5, IdProduct = 5, EntryDate = DateTime.Now, Price = 150.00m, Quantity = 25 },
                new Batch { IdBatch = 6, IdProduct = 6, EntryDate = DateTime.Now, Price = 50.00m, Quantity = 50 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { IdUser = 1, Name = "Admin User", Email = "admin@example.com", PasswordHash = "123456", FechaCreacion = DateTime.Now },
                new User { IdUser = 2, Name = "Regular User", Email = "user@example.com", PasswordHash = "asd123", FechaCreacion = DateTime.Now }
            );
            
        }

    }
}
