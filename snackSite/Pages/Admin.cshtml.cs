using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;
using snackSite.Helpers;

namespace snackSite.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty]
        public Budget? Budget  { get; set; }
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

        public IActionResult OnPost()
        {
            if (Budget.BudgetPrice <= 0)
            {
                ModelState.AddModelError("Gebruiker.Budget", "Budget mag niet negatief zijn");
                Redirect("/Admin");
            }

            BudgetRepository.UpdateBudget(Budget.BudgetPrice);
            
            // refresh page
            return Redirect("/Admin");
        }
    }
}
