using Microsoft.AspNetCore.Mvc.RazorPages;

namespace snackSite.Pages
{
    public class Order : PageModel
    {
        private readonly ILogger<Order> _logger;

        public Order(ILogger<Order> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}