using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDProducten;

public class Delete : PageModel
{

    public IEnumerable<Product> Producten { get; set; } = null!;
    public void OnGet([FromRoute] int ProductId)
    {
        Producten = new ProductenRepository().Delete(ProductId);
    }

    public IActionResult OnPostDelete([FromRoute] int ProductId)
    {
        bool success = new ProductenRepository().Delete(ProductId);
        return RedirectToPage(nameof(Index));
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage(nameof(Index));
    }
}