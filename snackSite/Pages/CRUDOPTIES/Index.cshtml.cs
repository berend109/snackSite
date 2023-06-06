using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDOPTIES;

public class Index : PageModel
{
    public IEnumerable <Optie> Opties { get; set; } = null!;
    public void OnGet()
    {
        Opties = new OptieRepository().GetOptie();
    }
}