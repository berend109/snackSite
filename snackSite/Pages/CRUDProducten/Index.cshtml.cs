using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.CRUDProducten;

public class Index : PageModel
{
    public IEnumerable <Product> Producten { get; set; } = null!;
    public void OnGet()
    {
        Producten = new ProductenRepository().GetProduct();
    }
}