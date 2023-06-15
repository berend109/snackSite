using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDGebruikers;

public class Update : PageModel
{
    public Gebruiker Gebruiker { get; set; } = null!;

    public void OnGet(int gebruikerId)
    {
        Gebruiker = new GebruikersRepository().Get(gebruikerId);
    }

    public IActionResult OnPost(Gebruiker gebruiker)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var updatedProduct = new GebruikersRepository().Update(gebruiker);

        return RedirectToPage("/Admin");
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage("/Admin");
    }
}