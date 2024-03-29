﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Helpers;
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
        [BindProperty] 
        public Bestelling Bestelling { get; set; } = null!;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        
        public IActionResult OnGet(string? searchTerm = null, string? searchTerm2 = null)
        {
            var session = new Session();
            var gebruiker = session.CheckIfLoggedIn(HttpContext.Session.GetString("user"));
            
            if (!gebruiker)
            {
                return Redirect("/Login");
            }
            
            Producten = new ProductenRepository().GetProduct();
            Opties = new OptieRepository().GetOptie();
            DateTime Datumweek = DateTime.Now;

            //Searchbar
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Producten = Producten.Where(Producten =>
                    (Producten.ProductNaam.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (Producten.AanbiederNaam.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }


            //oude code bedoelt voor de tijdelijke 2de Searchbar.
            //if (!string.IsNullOrEmpty(searchTerm2))
            //{
            //    Producten = Producten.Where(Producten => Producten.AanbiederNaam.Contains(searchTerm2));
            //}

            // if (!string.IsNullOrEmpty(searchTerm))
            // {
            //     Producten = Producten.Where(Producten => Producten.AanbiederNaam.Contains(searchTerm)); 
            // }

            return Page();
        }

        public IActionResult OnPostToevoegen(Optie optie, Aanbieder aanbieder, Product product)
        {
            
            var createdBestelling = new BestellingRepository().Add(Bestelling);
            return RedirectToPage();
        }
    }
}