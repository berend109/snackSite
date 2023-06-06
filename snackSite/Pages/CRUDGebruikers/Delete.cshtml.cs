using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDGebruikers;

public class Delete : PageModel
{
    public Gebruiker Gebruiker { get; set; } = null!;

    public void OnGet([FromRoute] int gebruikerId)
    {
        Gebruiker = new GebruikersRepository().Get(gebruikerId);

    }

    public IActionResult OnPostDelete([FromRoute] int gebruikerId)
    {
        bool success = new GebruikersRepository().Delete(gebruikerId);
        return RedirectToPage(nameof(Index));
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage(nameof(Index));
    }
}