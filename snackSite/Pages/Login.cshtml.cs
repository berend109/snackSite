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
        var user = UserRepository.Get(Gebruiker?.Email);
  
        // Check if user exists and if the password is correct
        // If so, set the password to null and store the user in the session
        if ((user != null) && (Hash.HashedPassword(Gebruiker?.Wachtwoord) == user.Wachtwoord))
        {
            user.Wachtwoord = null;

            var Gebruiker = JsonConvert.SerializeObject(user);
            HttpContext.Session.SetString("user", Gebruiker);

            return Redirect("/index");
        }
        return Page();
    }
}