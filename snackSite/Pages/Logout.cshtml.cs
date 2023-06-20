using Microsoft.AspNetCore.Mvc.RazorPages;

namespace snackSite.Pages;

public class Logout : PageModel
{
    public void OnGet()
    {   
        HttpContext.Session.Clear();
        Response.Redirect("/Index");
    }
}