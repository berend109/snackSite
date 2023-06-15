using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDProducten;

public class Create : PageModel
{
    [BindProperty] public Product Product { get; set; } = null!;
    public IEnumerable<Aanbieder> Aanbieders { get; set; } = null!;

    public void OnGet()
    {
        Aanbieders = new AanbiedersRepository().GetAanbieder();
    }

    public IActionResult OnPost(Product product)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var createdProduct = new ProductenRepository().Add(Product);
        // var aanbieder = new ProductenRepository().AddHeeftEenProduct(aanbiederId, createdProduct.ProductId);
        return RedirectToPage("../Admin");
    }

    public IActionResult OnPostCancel()
    {
        return Redirect("../Admin");
    }
}