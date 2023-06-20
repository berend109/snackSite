using Microsoft.AspNetCore.Mvc.RazorPages;
using snackSite.Models;
using snackSite.Repositories;

namespace snackSite.Pages.Crud.CRUDAanbieders;

public class Index : PageModel
{
    public IEnumerable<Aanbieder> Aanbieders { get; set; } = null!;
    public void OnGet()
    {
        Aanbieders = new AanbiedersRepository().GetAanbieder();
    }
}