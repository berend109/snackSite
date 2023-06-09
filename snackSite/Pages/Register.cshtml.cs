using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Helper;
using snackSite.Helpers;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages;

public class RegisterModel : PageModel
{
    [BindProperty]
    public User user { get; set; }

    public IActionResult OnGet()
    {
        Session session = new Session();
        bool user = session.CheckIfLoggedIn(HttpContext.Session.GetString("user"));

        return user ? Redirect("/Index") : Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        User existingUser = UserRepository.Get(user.Email);

        if (existingUser == null && user.Password == user.Password2)
        {
            new UserRepository().Add(user.Name, Hash.HashPassword(user.Password), user.Email);
            return Redirect("/Login");
        }

        return Redirect("/Register");
    }
}