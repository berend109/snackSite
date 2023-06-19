using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;
using snackSite.Helpers;

namespace snackSite.Pages
{
    public class AdminModel : PageModel
    {
        public IEnumerable <Product> Producten { get; set; } = null!;
        public IEnumerable <Optie> Opties { get; set; } = null!;
        public IEnumerable<Gebruiker> Gebruikers { get; set; } = null!;
        public IActionResult OnGet()
        {
            Producten = new ProductenRepository().GetProduct();
            Opties = new OptieRepository().GetOptie();
            Gebruikers = new GebruikersRepository().GetGebruiker();
            
            var session = new Session();
            bool auth = session.CheckAdmin(HttpContext.Session.GetString("user"));
            
            return auth ? Page() : Redirect("/Index");
        }
    }
}
