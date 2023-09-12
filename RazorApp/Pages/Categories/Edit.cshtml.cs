using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Data;
using RazorApp.Model;

namespace RazorApp.Pages.Categories;

// multiple properties
[BindProperties]
public class Edit : PageModel
{
    private readonly ApplicationDbContext _db;

    public Edit(ApplicationDbContext db)
    {
        _db = db;
    }

    // [BindProperty]
    public Category Category { get; set; }

    public void OnGet(int id)
    {
        Category = _db.Category.FirstOrDefault(c => c.Id == id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (string.IsNullOrEmpty(Category.Name))
        {
            ModelState.AddModelError(string.Empty, "The Name field is required on god.");
            return Page();
        }

        if (ModelState.IsValid)
        {
            _db.Category.Update(Category);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        return Page();
    }
}