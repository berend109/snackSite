//using snackSite.Models;
//using snackSite.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Product = snackSite.Models.Product;


//namespace snackSite.Pages.Bestel;

//public class Bestellen : PageModel
//{
//    public IEnumerable<Aanbieder> Aanbieders { get; set; }
//    public IEnumerable<Product> Producten { get; set; }

//    public IEnumerable<Optie> BestellingItems { get; set; }

//    public int Order_id { get; set; }

//    public int Tafel { get; set; }



//    public IActionResult OnGet()
//    {
        
//        if (check == null)
//        { return RedirectToPage("/Accounts/Login"); }

//        Aanbieder = new AanbiedersRepository().Get();
//        Product = new ProductenRepository().Get();

//        Tafel = Convert.ToInt32(Request.Cookies["tafel"]);
//        if (Tafel == 0)
//        {
//            return RedirectToPage("/Bestel/Tafelscherm");
//        }

//        Order_id = new BestellingRepository().GetLastOpenOrder(Tafel);
//        BestellingItems = new BestellingitemsRepository().Get(Order_id);

//        return Page();
//    }

//    // Voegt product toe aan de basket toe
//    public IActionResult OnPost([FromForm] int ProductId, [FromForm] int Order_id)
//    {
//        var items = new BestellingitemsRepository();
//        items.Add(ProductId, Order_id);
//        return RedirectToPage();
//    }

//    //verwijdert product uit de basket
//    public IActionResult OnPostDelete([FromForm] int productId, [FromForm] int Order_id)
//    {
//        var items = new BestellingitemsRepository();

//        items.Delete(Order_id, productId);

//        return RedirectToPage();
//    }

//    //Kan van een berpaald product de hoeveelheid naar beneden doen
//    public IActionResult OnPostIncrease([FromForm] int productId, [FromForm] int Order_id)
//    {
//        var items = new BestellingitemsRepository();

//        items.UpdatePlus(productId, Order_id);

//        return RedirectToPage();
//    }

//    //Kan van een berpaald product de hoeveelheid naar boven doen
//    public IActionResult OnPostDecrease([FromForm] int productId, [FromForm] int Order_id)
//    {
//        var items = new BestellingitemsRepository();
//        items.UpdateMin(productId, Order_id);
//        return RedirectToPage();
//    }

//    public IActionResult OnPostNextpage()
//    {
//        return RedirectToPage("/Bestel/Overzicht");
//    }

//}