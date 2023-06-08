using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages
{
    public class IndexModel : PageModel
    {
        private bool OptionSelected = false;
        public IEnumerable<Product> Producten { get; set; } = null!;
        public IEnumerable<Optie> Opties { get; set; } = null!;
        public int OptieID { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string? searchTerm = null)
        {
            Producten = new ProductenRepository().GetProduct();
            Opties = new OptieRepository().GetOptie();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Producten = Producten.Where(Producten => Producten.ProductNaam.Contains(searchTerm));
            }
        }
    }
}