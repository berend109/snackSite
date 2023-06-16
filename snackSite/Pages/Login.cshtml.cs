using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Repositories;
using snackSite.Helpers;
using Newtonsoft.Json;

namespace snackSite.Pages;

public class Login : PageModel
{
    private readonly ILogger<Login>? _logger;

    [BindProperty] 
    public string? Email { get; set; }
    [BindProperty] 
    public string? Password { get; set; }

    public IActionResult OnGet()
    {
        var session = new Session();
        bool Gebruiker = session.CheckIfLoggedIn(HttpContext.Session.GetString("user"));

        if (Gebruiker)
            return Redirect("/Index");

        return Page();
    }

    public IActionResult OnPost()
    {
        var gebruiker = UserRepository.Get(Email);
        
        if (gebruiker == null)
        {
            if (Password == "test")
            {
                var tempPassword = Hash.HashedPassword(Password);
                // make test user
                UserRepository.Add("test", tempPassword, Email);

                return Redirect("/index");
            }
            return Page();
        }
        
        if ((gebruiker != null) && (Hash.HashedPassword(Password) == gebruiker.Wachtwoord))
        {
            gebruiker.Wachtwoord = null;

            string Gebruiker = JsonConvert.SerializeObject(gebruiker);
            HttpContext.Session.SetString("gebruiker", Gebruiker);

            return Redirect("/index");
        }
        return Page();
    }
}