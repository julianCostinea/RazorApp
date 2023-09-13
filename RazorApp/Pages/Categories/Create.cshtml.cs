using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Data;
using RazorApp.Model;

namespace RazorApp.Pages.Categories;

// multiple properties
[BindProperties]
public class Create : PageModel
{
    private readonly ApplicationDbContext _db;

    public Create(ApplicationDbContext db)
    {
        _db = db;
    }

    // [BindProperty]
    public Category Category { get; set; }

    public void OnGet()
    {
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
            _db.Category.Add(Category);

            await _db.SaveChangesAsync();
            TempData["success"] = "Category has been created successfully.";

            return RedirectToPage("Index");
        }

        return Page();
    }
}