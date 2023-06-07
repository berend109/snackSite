using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDProducten;

public class Create : PageModel
{
    [BindProperty] public Product Product { get; set; } = null!;
    
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var createdProduct = new ProductenRepository().Add(Product);
        return RedirectToPage("../Admin");
    }

    public IActionResult OnPostCancel()
    {
        return Redirect("../Admin");
    }
}