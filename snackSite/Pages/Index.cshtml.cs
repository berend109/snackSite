using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages
{
    public class IndexModel : PageModel
    {
        private bool OptionSelected { get; set; }

        public Aanbieder Aanbieder { get; set; }

        public Product Product { get; set; }

        public Optie Optie { get; set; }
        public IEnumerable<Product> Producten { get; set; } = null!;
        public IEnumerable<Optie> Opties { get; set; } = null!;
        public int OptieID { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(string? searchTerm = null)
        {
            Producten = new ProductenRepository().GetProduct();
            Opties = new OptieRepository().GetOptie();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Producten = Producten.Where(Producten => Producten.ProductNaam.Contains(searchTerm));
            }

            return Page();
        }

        public IActionResult OnPostToevoegen(Optie optie, Aanbieder aanbieder, Product product)
        {
            return RedirectToPage();
        }
    }
}