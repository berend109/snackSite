using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDProducten;

public class Update : PageModel
{
    public Product Product { get; set; } = null!;
    
    public void OnGet(int productId)
    {
         Product = new ProductenRepository().Get(productId);
    }

    public IActionResult OnPost(Product product)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var updatedProduct = new ProductenRepository().Update(product);

        return RedirectToPage(nameof(Index));
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage(nameof(Index));
    }
}