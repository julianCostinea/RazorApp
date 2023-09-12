using System.ComponentModel.DataAnnotations;

namespace RazorApp.Model;

public class Category
{
    
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Display(Name = "Display Order frfr")]
    [Range(1, 100, ErrorMessage = "Display Order for category must be between 1 and 100.")]
    public int DisplayOrder { get; set; }
}