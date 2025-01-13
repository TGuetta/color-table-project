using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db)
    {
        _db = db;
    }

    public List<ColorItem> Colors { get; set; } = new List<ColorItem>();

    public async Task OnGetAsync()
    {
        Colors = await _db.Colors.ToListAsync();
    }
}

