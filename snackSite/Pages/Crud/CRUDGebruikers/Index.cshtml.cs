using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.Crud.CRUDGebruikers;

public class Index : PageModel
{
    public IEnumerable<Gebruiker> Gebruikers { get; set; } = null!;
    public void OnGet()
    {
        Gebruikers = new GebruikersRepository().GetGebruiker();
    }
}