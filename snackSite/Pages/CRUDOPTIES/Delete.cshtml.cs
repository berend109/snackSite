using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDOPTIES;

public class Delete : PageModel
{
    public Optie Optie { get; set; } = null!;
 
    public void OnGet([FromRoute] int optieId)
    {
        Optie = new OptieRepository().Get(optieId);

    }

    public IActionResult OnPostDelete([FromRoute] int optieId)
    {
        bool success = new OptieRepository().Delete(optieId);
        return RedirectToPage(nameof(CRUDOPTIES.Index));
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage(nameof(CRUDOPTIES.Index));
    }
}