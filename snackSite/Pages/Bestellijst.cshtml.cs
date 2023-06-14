using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages;

public class Bestellijst : PageModel
{
    public IEnumerable<Bestelling> Besteld { get; set; } = null!;

    public void OnGet()
    {
        Besteld = new BestellingRepository().GetBesteld();
        

    }
}