using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Repositories;
using Newtonsoft.Json;
using snackSite.Helper;
using snackSite.Helpers;

namespace snackSite.Pages;

public class Login : PageModel
{
    private readonly ILogger<Login> _logger;

    [BindProperty] 
    public string Email { get; set; }
    [BindProperty] 
    public string Password { get; set; }
    [TempData]
    public string StatusMessage {get;set;}

    public IActionResult OnGet()
    {
        var session = new Session();
        bool user = session.CheckIfLoggedIn(HttpContext.Session.GetString("user"));

        if (user)
            return Redirect("/Index");

        return Page();
    }

    public IActionResult OnPost()
    {
        if (Password == "test")
        {
            var tempPassword = Hash.HashedPassword(Password);
            // make test user
            UserRepository.Add("test", tempPassword, Email);

            return Redirect("/index");
        }
        
        var gebruiker = UserRepository.Get(Email);
        if ((gebruiker != null) && (Hash.HashedPassword(Password) == gebruiker.Wachtwoord))
        {
            gebruiker.Wachtwoord = null;

            string user = JsonConvert.SerializeObject(gebruiker);
            HttpContext.Session.SetString("user", user);

            return Redirect("/index");
        }
        StatusMessage = "An error occurred while saving customer data!";
        return Page();
    }
}