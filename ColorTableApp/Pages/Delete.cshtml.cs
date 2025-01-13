using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _db;

    public DeleteModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public ColorItem? Color { get; set; } // Updated to use ColorItem

    public IActionResult OnGet(int id)
    {
        //Console.WriteLine($"Fetching color with ID: {id} for deletion.");
        Color = _db.Colors.FirstOrDefault(c => c.Id == id);

        if (Color == null)
        {
            Console.WriteLine($"Color with ID {id} not found.");
            return RedirectToPage("./Index");
        }

        Console.WriteLine($"Color fetched for deletion: {Color.ColorName}");
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        //Console.WriteLine($"Delete requested for color with ID: {id}");

        var color = _db.Colors.FirstOrDefault(c => c.Id == id);

        if (color == null)
        {
            Console.WriteLine($"Color with ID {id} not found in the database.");
            return RedirectToPage("./Index");
        }

        Console.WriteLine($"Deleting color: {color.ColorName}");
        _db.Colors.Remove(color);
        _db.SaveChanges();
        Console.WriteLine($"Color with ID {id} successfully deleted.");

        return RedirectToPage("./Index");
    }
}

