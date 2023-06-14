using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages;

public class Bestellijst : PageModel
{
    public IEnumerable<Bestelling> Besteld { get; set; } = null!;
    public IEnumerable<Bestelling> Week { get; set; } = null!;

    public void OnGet(DateTime week)
    {
        Besteld = new BestellingRepository().GetBesteld();
        Week = new BestellingRepository().GetDatum(week);


    }

    
}