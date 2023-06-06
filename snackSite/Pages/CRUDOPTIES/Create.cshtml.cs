using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDOPTIES;

public class Create : PageModel

{
    [BindProperty ]public Optie Optie { get; set; } = null!;
    public void OnGet()
    {
        
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var createdOptie = new OptieRepository().Add(Optie);
        return RedirectToPage("../Admin");
    }
    public IActionResult OnPostCancel()
    {
        return Redirect("../Admin");
    }
}