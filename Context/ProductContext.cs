using Microsoft.EntityFrameworkCore;
using CapstoneBackend.Models;

namespace CapstoneBackend.Data;

public class ProductContext : DbContext
{
    public DbSet<Product>? Products { get; set; }
    public ProductContext(DbContextOptions<ProductContext> options)
    : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=CapstoneDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    internal object FindAsync(int id)
    {
        throw new NotImplementedException();
    }
}


//Add model to table -> code first EF
//Add DbSet and run dotnet ef migrations add {Name}
//then run dotnet ef database update to do that exactly