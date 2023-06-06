using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDGebruikers
{

    public class Create : PageModel
    {
        [BindProperty] public Gebruiker Gebruiker { get; set; } = null!;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var createdGebruiker = new GebruikersRepository().Add(Gebruiker);
            return RedirectToPage(nameof(Index));
        }

        public IActionResult OnPostCancel()
        {
            return Redirect(nameof(Index));
        }
    }
}