using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDAanbieders;

public class Update : PageModel
{
    public Aanbieder Aanbieder { get; set; } = null!;

    public void OnGet(int aanbiederId)
    {
        Aanbieder = new AanbiedersRepository().Get(aanbiederId);
    }

    public IActionResult OnPost(Aanbieder aanbieder)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var updatedAanbieder = new AanbiedersRepository().Update(aanbieder);

        return RedirectToPage(nameof(Index));
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage(nameof(Index));
    }
}