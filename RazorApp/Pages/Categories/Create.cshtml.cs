using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Data;
using RazorApp.Model;

namespace RazorApp.Pages.Categories;

public class Create : PageModel
{
    
    private readonly ApplicationDbContext _db;
    
    public Create(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public Category Category { get; set; }
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPost(Category category)
    {
        _db.Category.Add(category);
        
        await _db.SaveChangesAsync();
        
        return RedirectToPage("Index");
    }
}