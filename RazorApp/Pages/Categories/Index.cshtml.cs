using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Data;
using RazorApp.Model;

namespace RazorApp.Pages.Categories;

public class Index : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Category> Categories { get; set; }
    
    public Index(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        Categories = _db.Category.ToList();
    }
    
    public async Task<IActionResult> OnPostDelete(int id)
    {
        var category = await _db.Category.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        _db.Category.Remove(category);
        await _db.SaveChangesAsync();
        
        TempData["success"] = "Category has been deleted successfully.";

        return RedirectToPage("Index");
    }
}