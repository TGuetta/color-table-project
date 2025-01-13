using Microsoft.EntityFrameworkCore; // Add this to configure your DbContext
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles(); // Added line to serve static files
// app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Database initialization logic
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Colors.Any())
    {
        db.Colors.AddRange(
            new ColorItem { ColorName = "Red", Price = 35, DisplayOrder = 1, InStock = true },
            new ColorItem { ColorName = "Blue", Price = 42, DisplayOrder = 2, InStock = false }
        );
        db.SaveChanges();
    }
}

app.Run();

