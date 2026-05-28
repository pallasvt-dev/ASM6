using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLBanHang.Models;

namespace QLBanHang.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Laptop", Description = "Các loại laptop" },
            new Category { Id = 2, Name = "Điện thoại", Description = "Các loại điện thoại" },
            new Category { Id = 3, Name = "Tablet", Description = "Các loại máy tính bảng" }
        );

        builder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop Dell XPS 13", Price = 25000000, Description = "Laptop cao cấp", CategoryId = 1 },
            new Product { Id = 2, Name = "Laptop HP EliteBook", Price = 18000000, Description = "Laptop văn phòng", CategoryId = 1 },
            new Product { Id = 3, Name = "iPhone 15 Pro", Price = 30000000, Description = "Điện thoại Apple", CategoryId = 2 },
            new Product { Id = 4, Name = "Samsung Galaxy S24", Price = 22000000, Description = "Điện thoại Samsung", CategoryId = 2 },
            new Product { Id = 5, Name = "iPad Pro 12.9", Price = 28000000, Description = "Máy tính bảng Apple", CategoryId = 3 }
        );
    }
}
