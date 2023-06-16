using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages
{
    public class AdminModel : PageModel
    {
        public IEnumerable <Product> Producten { get; set; } = null!;
        public IEnumerable <Optie> Opties { get; set; } = null!;
        public IEnumerable<Gebruiker> Gebruikers { get; set; } = null!;
        public void OnGet()
        {
            Producten = new ProductenRepository().GetProduct();
            Opties = new OptieRepository().GetOptie();
            Gebruikers = new GebruikersRepository().GetGebruiker();
        }
    }
}
