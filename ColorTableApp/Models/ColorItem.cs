using System.ComponentModel.DataAnnotations;

public class ColorItem // Rename the class
{
    public int Id { get; set; }

    [Required]
    public string? ColorName { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number.")]
    public int Price { get; set; }

    public int DisplayOrder { get; set; }
    public bool InStock { get; set; }
}

