using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Repositories;
using snackSite.Helpers;
using Newtonsoft.Json;
using snackSite.Models;

namespace snackSite.Pages;

public class Login : PageModel
{
    [BindProperty] 
    public Gebruiker? Gebruiker { get; set; }
    
    public IActionResult OnGet()
    {
        var session = new Session();
        var gebruiker = session.CheckIfLoggedIn(HttpContext.Session.GetString("user"));

        return gebruiker ? Redirect("/Index") : Page();
    }

    public IActionResult OnPost()
    {
        var gebruiker = UserRepository.Get(Gebruiker?.Email);
  
        if ((gebruiker != null) && (Hash.HashedPassword(Gebruiker?.Wachtwoord) == gebruiker.Wachtwoord))
        {
            gebruiker.Wachtwoord = null;

            var Gebruiker = JsonConvert.SerializeObject(gebruiker);
            HttpContext.Session.SetString("user", Gebruiker);

            return Redirect("/index");
        }
        return Page();
    }
}