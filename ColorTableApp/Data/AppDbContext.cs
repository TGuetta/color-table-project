using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<ColorItem> Colors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data/Colors.db");
    }
}

public class Color
{
    public int Id { get; set; }
    public string? ColorName { get; set; }
    public int Price { get; set; }
    public int DisplayOrder { get; set; }
    public bool InStock { get; set; }
}

