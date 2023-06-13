using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDAanbieders
{
    public class Create : PageModel
    {
        [BindProperty] public Aanbieder Aanbieder { get; set; } = null!;
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var createdAanbieder = new AanbiedersRepository().Add(Aanbieder);
            return RedirectToPage(nameof(Index));
        }

        public IActionResult OnPostCancel()
        {
            return Redirect(nameof(Index));
        }
    }
}
