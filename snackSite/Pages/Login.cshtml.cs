using Microsoft.AspNetCore.Mvc.RazorPages;

namespace snackSite.Pages
{
    public class Login : PageModel
    {
        private readonly ILogger<Login> _logger;

        public Login(ILogger<Login> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}