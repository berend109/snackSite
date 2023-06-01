using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDOPTIES;

public class Update : PageModel
{
    public Optie Optie { get; set; } = null!;
    
    public void OnGet(int optieId)
    {
        Optie = new OptieRepository().Get(optieId);
    }

    public IActionResult OnPost(Optie optie)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var updatedOptie = new OptieRepository().Update(optie);

        return RedirectToPage(nameof(Index));
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage(nameof(Index));
    }
}