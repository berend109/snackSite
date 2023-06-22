using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using snackSite.Helpers;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages;

public class Register : PageModel
{
    [BindProperty]
    public Gebruiker? Gebruiker { get; set; }
   
    public IActionResult OnGet()
    {
        var session = new Session();
        var user = session.CheckIfLoggedIn(HttpContext.Session.GetString("user"));
        
        return user ? Redirect("/Index") : Page();
    }

    public IActionResult OnPost()
    {
        if (UserRepository.Get(Gebruiker?.Email) is not null)
        {
            return Redirect("/Login");
        }
        UserRepository.Add(Gebruiker.Naam, Hash.HashedPassword(Gebruiker.Wachtwoord), Gebruiker.Email);
        return Redirect("/Index");
    }
}
