using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDAanbieders;

public class Delete : PageModel
{
    public Aanbieder Aanbieder { get; set; } = null!;

    public void OnGet([FromRoute] int aanbiederId)
    {
        Aanbieder = new AanbiedersRepository().Get(aanbiederId);

    }

    public IActionResult OnPostDelete([FromRoute] int aanbiederId)
    {
        bool success = new ProductenRepository().Delete(aanbiederId);
        return RedirectToPage(nameof(Index));
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage(nameof(Index));
    }
}