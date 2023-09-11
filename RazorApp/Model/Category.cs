using System.ComponentModel.DataAnnotations;

namespace RazorApp.Model;

public class Category
{
    
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
}