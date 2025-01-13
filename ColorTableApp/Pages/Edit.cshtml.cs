using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

public class EditModel : PageModel
{
    private readonly AppDbContext _db;

    public EditModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public ColorItem? Color { get; set; } // Updated to use ColorItem

    public IActionResult OnGet(int id)
    {
        Console.WriteLine($"Fetching color with ID: {id}");
        Color = _db.Colors.FirstOrDefault(c => c.Id == id);

        if (Color == null)
        {
            Console.WriteLine("Color not found.");
            return RedirectToPage("./Index");
        }

        Console.WriteLine($"Fetched color: {Color.ColorName}");
        return Page();
    }

    public IActionResult OnPost()
    {
        Console.WriteLine($"Submitted Id: {Color?.Id}");

        if (Color == null)
        {
            Console.WriteLine("Color is null.");
            return RedirectToPage("./Index"); // Redirect if the Color is null
        }

        Console.WriteLine($"Submitted Color: {Color.ColorName}, Price: {Color.Price}, DisplayOrder: {Color.DisplayOrder}, InStock: {Color.InStock}");

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Model state is invalid.");
            return Page();
        }

        var colorInDb = _db.Colors.FirstOrDefault(c => c.Id == Color.Id);

        if (colorInDb == null)
        {
            Console.WriteLine("Color not found in database.");
            return RedirectToPage("./Index"); // Redirect if the color is not found
        }

        // Update the color details
        colorInDb.ColorName = Color.ColorName!;
        colorInDb.Price = Color.Price;
        colorInDb.DisplayOrder = Color.DisplayOrder;
        colorInDb.InStock = Color.InStock;

        _db.SaveChanges();
        Console.WriteLine($"Updated color: {colorInDb.ColorName}");
        return RedirectToPage("./Index");
    }
}

