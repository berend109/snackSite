using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;
using snackSite.Helper;

namespace snackSite.Pages;

public class Register : PageModel
{
    [BindProperty]
    public User? user { get; set; }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        User existingUser = UserRepository.Get(user.Email);

        if (existingUser == null && user.Password == user.Password2)
        {
            UserRepository.Add(user.Name, Hasj.HashPassword(user.Password));
            return RedirectToPage("/Index");
        }

        return RedirectToPage("/Register");
    }
}