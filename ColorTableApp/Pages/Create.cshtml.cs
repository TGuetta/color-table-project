using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateModel : PageModel
{
    private readonly AppDbContext _db;

    public CreateModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public ColorItem NewColor { get; set; } = new ColorItem();

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("Model state is invalid.");
            return Page(); // Redisplay the form with validation errors
        }

        Console.WriteLine($"Adding Color: {NewColor.ColorName}, Price: {NewColor.Price}, DisplayOrder: {NewColor.DisplayOrder}, InStock: {NewColor.InStock}");

        _db.Colors.Add(NewColor);
        _db.SaveChanges();

        Console.WriteLine("Color successfully added to the database.");
        return RedirectToPage("./Index");
    }
}

