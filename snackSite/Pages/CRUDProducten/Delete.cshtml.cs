using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDProducten;

public class Delete : PageModel
{
    public Product Product { get; set; } = null!;
 
    public void OnGet([FromRoute] int productId)
    {
        Product = new ProductenRepository().Get(productId);

    }

    public IActionResult OnPostDelete([FromRoute] int productId)
    {
        bool success = new ProductenRepository().Delete(productId);
        return RedirectToPage("../Admin");
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage("../Admin");
    }
}